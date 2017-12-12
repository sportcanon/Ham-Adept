using System;
using System.Windows;
using System.Windows.Threading;

namespace HamAdept.Extensions
{
    public static class DependencyObjectExtensions
    {
        // methods
        #region InvokeThreadSafe

        public static void InvokeThreadSafe(this Dispatcher source, Action action)
        {
            if (!source.CheckAccess())
                source.BeginInvoke(action);
            else
                action();
        }

        public static void InvokeThreadSafe<T>(this Dispatcher source, Action<T> action, T parameter)
        {
            if (!source.CheckAccess())
                source.BeginInvoke(action, parameter);
            else
                action(parameter);
        }

        public static void InvokeThreadSafe<T1, T2>(this Dispatcher source, Action<T1, T2> action, T1 p1, T2 p2)
        {
            if (!source.CheckAccess())
                source.BeginInvoke(action, p1, p2);
            else
                action(p1, p2);
        }

        public static void InvokeThreadSafe<T1, T2, T3>(this Dispatcher source, Action<T1, T2, T3> action, T1 p1, T2 p2, T3 p3)
        {
            if (!source.CheckAccess())
                source.BeginInvoke(action, p1, p2, p3);
            else
                action(p1, p2, p3);
        }

        public static void InvokeThreadSafe<T1, T2, T3, T4>(this Dispatcher source, Action<T1, T2, T3, T4> action, T1 p1, T2 p2, T3 p3, T4 p4)
        {
            if (!source.CheckAccess())
                source.BeginInvoke(action, p1, p2, p3, p4);
            else
                action(p1, p2, p3, p4);
        }

#if !WINDOWS_PHONE

        public static void InvokeThreadSafe<T1, T2, T3, T4, T5>(this Dispatcher source, Action<T1, T2, T3, T4, T5> action, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
        {
            if (!source.CheckAccess())
                source.BeginInvoke(action, p1, p2, p3, p4, p5);
            else
                action(p1, p2, p3, p4, p5);
        }
#endif

        public static void InvokeThreadSafe(this DependencyObject source, Action action)
        {
            source.Dispatcher.InvokeThreadSafe(action);
        }

        public static void InvokeThreadSafe<T>(this DependencyObject source, Action<T> action, T parameter)
        {
            source.Dispatcher.InvokeThreadSafe(action, parameter);
        }


        public static void InvokeThreadSafe<T1, T2>(this DependencyObject source, Action<T1, T2> action, T1 p1, T2 p2)
        {
            source.Dispatcher.InvokeThreadSafe(action, p1, p2);
        }

        public static void InvokeThreadSafe<T1, T2, T3>(this DependencyObject source, Action<T1, T2, T3> action, T1 p1, T2 p2, T3 p3)
        {
            source.Dispatcher.InvokeThreadSafe(action, p1, p2, p3);
        }

        public static void InvokeThreadSafe<T1, T2, T3, T4>(this DependencyObject source, Action<T1, T2, T3, T4> action, T1 p1, T2 p2, T3 p3, T4 p4)
        {
            source.Dispatcher.InvokeThreadSafe(action, p1, p2, p3, p4);
        }

#if !WINDOWS_PHONE

        public static void InvokeThreadSafe<T1, T2, T3, T4, T5>(this DependencyObject source, Action<T1, T2, T3, T4, T5> action, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
        {
            source.Dispatcher.InvokeThreadSafe(action, p1, p2, p3, p4, p5);
        }
#endif

        #endregion
    }
}