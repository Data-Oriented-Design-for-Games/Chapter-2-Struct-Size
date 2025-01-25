using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Runtime.InteropServices;

namespace DOD_BOOK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StructBytes4
    {
        public int a;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructBytes8
    {
        public int a;
        public int b;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructBytes12
    {
        public int a;
        public int b;
        public int c;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructBytes16
    {
        public int a;
        public int b;
        public int c;
        public int d;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructBytes20
    {
        public int a;
        public int b;
        public int c;
        public int d;
        public int e;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructBytes24
    {
        public int a;
        public int b;
        public int c;
        public int d;
        public int e;
        public int f;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructBytes64
    {
        public int a;
        public int b;
        public int c;
        public int d;
        public int e;
        public int f;
        public int g;
        public int h;
        public int i;
        public int j;
        public int k;
        public int l;
        public int m;
        public int n;
        public int o;
        public int p;
    }

    public class Main : MonoBehaviour
    {
        public TextMeshProUGUI ResultText;
        public TextMeshProUGUI ButtonText;
        public int NumIterations = 10000;
        public int NumTests = 1000;

        bool m_runTest = false;

        double[] m_time = new double[8];

        public int PublicTotal = 0;

        StructBytes4 m_structBytes4;
        StructBytes8 m_structBytes8;
        StructBytes12 m_structBytes12;
        StructBytes16 m_structBytes16;
        StructBytes20 m_structBytes20;
        StructBytes24 m_structBytes24;
        StructBytes64 m_structBytes64;

        private void Awake()
        {
            ResultText.text = "Ready\n";
        }

        public void RunTest()
        {
            m_runTest = true;
        }

        private void Update()
        {

            if (m_runTest)
            {
                double time = 0.0d;
                for (int i = 0; i < m_time.Length; i++)
                    m_time[i] = 0.0d;

                for (int i = 0; i < NumIterations; i++)
                {
                    int count = 0;

                    time = Time.realtimeSinceStartupAsDouble;
                    for (int j = 0; j < NumTests; j++)
                        m_structBytes4 = PassStruct4(m_structBytes4, j);
                    m_time[count++] += Time.realtimeSinceStartupAsDouble - time;

                    time = Time.realtimeSinceStartupAsDouble;
                    for (int j = 0; j < NumTests; j++)
                        m_structBytes8 = PassStruct8(m_structBytes8, j);
                    m_time[count++] += Time.realtimeSinceStartupAsDouble - time;

                    time = Time.realtimeSinceStartupAsDouble;
                    for (int j = 0; j < NumTests; j++)
                        m_structBytes12 = PassStruct12(m_structBytes12, j);
                    m_time[count++] += Time.realtimeSinceStartupAsDouble - time;

                    time = Time.realtimeSinceStartupAsDouble;
                    for (int j = 0; j < NumTests; j++)
                        m_structBytes16 = PassStruct16(m_structBytes16, j);
                    m_time[count++] += Time.realtimeSinceStartupAsDouble - time;

                    time = Time.realtimeSinceStartupAsDouble;
                    for (int j = 0; j < NumTests; j++)
                        m_structBytes20 = PassStruct20(m_structBytes20, j);
                    m_time[count++] += Time.realtimeSinceStartupAsDouble - time;

                    time = Time.realtimeSinceStartupAsDouble;
                    for (int j = 0; j < NumTests; j++)
                        m_structBytes24 = PassStruct24(m_structBytes24, j);
                    m_time[count++] += Time.realtimeSinceStartupAsDouble - time;

                    time = Time.realtimeSinceStartupAsDouble;
                    for (int j = 0; j < NumTests; j++)
                        m_structBytes64 = PassStruct64(m_structBytes64, j);
                    m_time[count++] += Time.realtimeSinceStartupAsDouble - time;

                    PublicTotal += m_structBytes4.a + m_structBytes8.a + m_structBytes12.a + m_structBytes16.a + m_structBytes20.a + m_structBytes24.a + m_structBytes64.a;
                }

                ResultText.text = "Test finished\n";
                ResultText.text += "Struct4 " + m_time[0].ToString("G4") + "\n";
                ResultText.text += "Struct8 " + m_time[1].ToString("G4") + " " + (m_time[1] / m_time[0]).ToString("G4") + "%" + "\n";
                ResultText.text += "Struct12 " + m_time[2].ToString("G4") + " " + (m_time[2] / m_time[0]).ToString("G4") + "%" + "\n";
                ResultText.text += "Struct16 " + m_time[3].ToString("G4") + " " + (m_time[3] / m_time[0]).ToString("G4") + "%" + "\n";
                ResultText.text += "Struct20 " + m_time[4].ToString("G4") + " " + (m_time[4] / m_time[0]).ToString("G4") + "%" + "\n";
                ResultText.text += "Struct24 " + m_time[5].ToString("G4") + " " + (m_time[5] / m_time[0]).ToString("G4") + "%" + "\n";
                ResultText.text += "Struct64 " + m_time[6].ToString("G4") + " " + (m_time[6] / m_time[0]).ToString("G4") + "%" + "\n";

                m_runTest = false;
            }
        }

        public static StructBytes4 PassStruct4(StructBytes4 structBytes4, int value)
        {
            structBytes4.a += value;
            return structBytes4;
        }

        public static StructBytes8 PassStruct8(StructBytes8 structBytes8, int value)
        {
            structBytes8.a += value;
            return structBytes8;
        }

        public static StructBytes12 PassStruct12(StructBytes12 structBytes12, int value)
        {
            structBytes12.a += value;
            return structBytes12;
        }

        public static StructBytes16 PassStruct16(StructBytes16 structBytes16, int value)
        {
            structBytes16.a += value;
            return structBytes16;
        }

        public static StructBytes20 PassStruct20(StructBytes20 structBytes20, int value)
        {
            structBytes20.a += value;
            return structBytes20;
        }

        public static StructBytes24 PassStruct24(StructBytes24 structBytes24, int value)
        {
            structBytes24.a += value;
            return structBytes24;
        }

        public static StructBytes64 PassStruct64(StructBytes64 structBytes64, int value)
        {
            structBytes64.a += value;
            return structBytes64;
        }
    }
}