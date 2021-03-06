using System;
using System.Collections.Generic;

/// <summary>
/// System.Collections.Generic.List.RemoveRange(Int32,Int32)
/// </summary>
public class ListRemoveRange
{
    #region Public Methods
    public bool RunTests()
    {
        bool retVal = true;

        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        retVal = PosTest2() && retVal;
        retVal = PosTest3() && retVal;

        TestLibrary.TestFramework.LogInformation("[Negative]");
        retVal = NegTest1() && retVal;
        retVal = NegTest2() && retVal;
        retVal = NegTest3() && retVal;

        return retVal;
    }

    #region Positive Test Cases
    public bool PosTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest1: Remove all the elements in the int type list");

        try
        {
            int[] iArray = { 1, 9, 3, 6, -1, 8, 7, 10, 2, 4 };
            List<int> listObject = new List<int>(iArray);
            listObject.RemoveRange(0, 10);
            if (listObject.Count != 0)
            {
                TestLibrary.TestFramework.LogError("001", "The result is not the value as expected,count is: " + listObject.Count);
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("002", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }

    public bool PosTest2()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest2: The generic type is type of string");

        try
        {
            string[] strArray = { "dog", "apple", "joke", "banana", "chocolate", "dog", "food" };
            List<string> listObject = new List<string>(strArray);
            listObject.RemoveRange(3, 3);
            string[] expected = { "dog", "apple", "joke", "food" };
            for (int i = 0; i < 4; i++)
            {
                if (listObject[i] != expected[i])
                {
                    TestLibrary.TestFramework.LogError("003", "The result is not the value as expected,result is: " + listObject[i]);
                    retVal = false;
                }
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("004", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }

    public bool PosTest3()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest3: The count argument is zero");

        try
        {
            MyClass myclass1 = new MyClass();
            MyClass myclass2 = new MyClass();
            MyClass myclass3 = new MyClass();
            MyClass[] mc = new MyClass[3] { myclass1, myclass2, myclass3 };
            List<MyClass> listObject = new List<MyClass>(mc);
            listObject.RemoveRange(1, 0);
            for (int i = 0; i < 3; i++)
            {
                if (listObject[i] != mc[i])
                {
                    TestLibrary.TestFramework.LogError("005", "The result is not the value as expected,result is: " + listObject[i]);
                    retVal = false;
                }
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("006", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    #endregion

    #region Nagetive Test Cases
    public bool NegTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest1: The index is a negative number");

        try
        {
            int[] iArray = { 1, 9, 3, 6, -1, 8, 7, 10, 2, 4 };
            List<int> listObject = new List<int>(iArray);
            listObject.RemoveRange(-1, 3);
            TestLibrary.TestFramework.LogError("101", "The ArgumentOutOfRangeException was not thrown as expected");
            retVal = false;
        }
        catch (ArgumentOutOfRangeException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("102", "Unexpected exception: " + e);
            TestLibrary.TestFramework.LogInformation(e.StackTrace);
            retVal = false;
        }

        return retVal;
    }

    public bool NegTest2()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest2: The count is a negative number");

        try
        {
            int[] iArray = { 1, 9, 3, 6, -1, 8, 7, 10, 2, 4 };
            List<int> listObject = new List<int>(iArray);
            listObject.RemoveRange(3, -2);
            TestLibrary.TestFramework.LogError("103", "The ArgumentOutOfRangeException was not thrown as expected");
            retVal = false;
        }
        catch (ArgumentOutOfRangeException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("104", "Unexpected exception: " + e);
            TestLibrary.TestFramework.LogInformation(e.StackTrace);
            retVal = false;
        }

        return retVal;
    }

    public bool NegTest3()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest3: index and count do not denote a valid range of elements in the List");

        try
        {
            string[] strArray = { "dog", "apple", "joke", "banana", "chocolate", "dog", "food" };
            List<string> listObject = new List<string>(strArray);
            listObject.RemoveRange(3, 10);
            TestLibrary.TestFramework.LogError("105", "The ArgumentException was not thrown as expected");
            retVal = false;
        }
        catch (ArgumentException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("106", "Unexpected exception: " + e);
            TestLibrary.TestFramework.LogInformation(e.StackTrace);
            retVal = false;
        }

        return retVal;
    }
    #endregion
    #endregion

    public static int Main()
    {
        ListRemoveRange test = new ListRemoveRange();

        TestLibrary.TestFramework.BeginTestCase("ListRemoveRange");

        if (test.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }
}
public class MyClass
{
}