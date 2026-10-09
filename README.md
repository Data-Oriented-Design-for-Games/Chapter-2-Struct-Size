# Chapter 2 — Struct Size

Sample project for **Chapter 2** of [*High Performance Unity Game Development (Using data-oriented design)*](https://www.manning.com/books/high-performance-unity-game-development) by Nitzan Wilnai (Manning).

This is a small timing test. It passes structs of different sizes to a function by value and
measures how long the calls take. The question it answers: what does it cost to pass a struct
by value, and how does that cost change as the struct gets bigger?

## What it shows

- A struct passed by value is copied on every call. A bigger struct means more bytes to copy.
- The test uses seven structs of 4, 8, 12, 16, 20, 24 and 64 bytes. Each one is only a row of
  `int` fields.
- Every struct goes to a function that does the same tiny amount of work. The only thing that
  changes from one measurement to the next is the size of the struct.
- Each time is shown next to the time for the 4-byte struct, so the sizes are easy to compare.

## How the test works

All of the code is in one file, `Assets/Scripts/Main.cs`.

- `StructBytes4` to `StructBytes64` are the structs. The number in the name is the size in bytes.
- `PassStruct4` to `PassStruct64` are the functions being timed. Each takes one struct by value.
- `Main.RunTest` is called by the **Run Test** button. It sets a flag.
- `Main.Update` sees the flag, runs the whole test in a single frame, and writes the results.

For each struct size, the test calls the function `NumTests` times in a row (1000) and adds the
elapsed time to a total. It repeats that `NumIterations` times (10000). Time is read from
`Time.realtimeSinceStartupAsDouble`.

```csharp
public static int PassStruct8(StructBytes8 structBytes8)
{
    structBytes8.a = 0;
    return structBytes8.a;
}

// In Update(), once per struct size:
time = Time.realtimeSinceStartupAsDouble;
for (int j = 0; j < NumTests; j++)
    PassStruct8(m_structBytes8);
m_time[count++] += Time.realtimeSinceStartupAsDouble - time;
```

## Running it

1. Open the project in Unity **6000.3.22f1** (Unity 6.3 LTS) or newer.
2. Open `Assets/Scenes/MainScene.unity` and press **Play**.
3. Click the **Run Test** button. The screen does not update while the test runs. When it is
   done, the results appear as text on screen. Nothing is written to the Console.

To change how long the test runs, select the `Main` object in the scene and edit `NumIterations`
and `NumTests` in the Inspector.

## Reading the results

The output has one line per struct size:

```
Test finished
Struct4 <seconds>
Struct8 <seconds> <ratio>%
...
Struct64 <seconds> <ratio>%
```

- The first number is the total time in seconds for all the calls with that struct.
- The second number is that time divided by the `Struct4` time. It is a ratio, not a percentage,
  even though a `%` sign is printed after it. A value of 1 means the same time as `Struct4`. A
  value of 2 means twice as long.
- The numbers depend on your machine and on where you run the test. The Editor and a built
  player can give different results. Run it a few times before you compare.

## More samples

All sample projects for the book: https://github.com/Data-Oriented-Design-for-Games
