// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;

internal class MainApp
{
    private static int s_s = 0;

    public static void MethodThatAlwaysThrows_NoInline()
    {
        Console.WriteLine("In method that always throws");
        throw new Exception("methodthatalwaysthrows");
    }

    public static void MethodThatMightThrow_Inline()
    {
        if (s_s == 1)
        {
            throw new Exception();
        }
    }

    public static int Main()
    {
        try
        {
            MethodThatMightThrow_Inline();
            MethodThatAlwaysThrows_NoInline();
            return 99;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());

            return 100;
        }
    }
}


