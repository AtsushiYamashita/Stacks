﻿/// <summary>
/// Utility library.
/// <authority> ATSUSHI YAMASHITA. </authority>
/// </summary>
namespace AY_Util
{
    /// <summary>
    /// 配列を扱う処理をまとめた汎用クラス
    /// </summary>
    /// <typeparam name="T">配列要素の型名</typeparam>
    public class ArrayUtil<T>
    {
        /// <summary>
        /// 配列の要素を一部だけ安全に抜き出す。
        /// </summary>
        /// <param name="arr">要素を抜き出す配列</param>
        /// <param name="first">抜き出す配列の先頭インデックス</param>
        /// <param name="length">抜き出す配列の最大長。</param>
        /// <returns>抜き出された要素</returns>
        public static T[] Slice ( T[] arr, int first, int length )
        {
            if (length > arr.Length)
                return Slice( arr, first, arr.Length );
            T[] ret = new T[length];
            for (int i = 0; i < length; i++)
                ret[i] = arr[i + first];
            return ret;
        }

        public delegate void Func ( T t );
        public delegate void Func2 ( int index, T t );

        /// <summary>
        /// 全ての要素にある処理を行う。
        /// </summary>
        /// <param name="arr">対象の配列</param>
        /// <param name="f">処理の関数。</param>
        public static void ForEach ( T[] arr, Func f )
        {
            foreach (T t in arr) f( t );
        }

        /// <summary>
        /// 全ての要素にある処理を行う。
        /// </summary>
        /// <param name="arr">対象の配列</param>
        /// <param name="f">処理の関数。</param>
        public static void ForEach ( T[] arr, Func2 f )
        {
            for (int i = 0; i < arr.Length; i++) f( i, arr[i] );
        }
    }
}
