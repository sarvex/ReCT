using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace ReCT.CodeAnalysis.Symbols
{
    internal static class BuiltinFunctions
    {
        //Console
        public static readonly FunctionSymbol Print = new FunctionSymbol("Print", ImmutableArray.Create(new ParameterSymbol("text", TypeSymbol.String, 0)), TypeSymbol.Void);
        public static readonly FunctionSymbol Write = new FunctionSymbol("Write", ImmutableArray.Create(new ParameterSymbol("text", TypeSymbol.String, 0)), TypeSymbol.Void);
        public static readonly FunctionSymbol Input = new FunctionSymbol("Input", ImmutableArray<ParameterSymbol>.Empty, TypeSymbol.String);
        public static readonly FunctionSymbol Clear = new FunctionSymbol("Clear", ImmutableArray<ParameterSymbol>.Empty, TypeSymbol.Void);
        public static readonly FunctionSymbol SetCursor = new FunctionSymbol("SetCursor", ImmutableArray.Create(new ParameterSymbol("xCoord", TypeSymbol.Int, 0), new ParameterSymbol("yCoord", TypeSymbol.Int, 0)), TypeSymbol.Void);
        public static readonly FunctionSymbol GetSizeX = new FunctionSymbol("GetSizeX", ImmutableArray<ParameterSymbol>.Empty, TypeSymbol.Int);
        public static readonly FunctionSymbol GetSizeY = new FunctionSymbol("GetSizeY", ImmutableArray<ParameterSymbol>.Empty, TypeSymbol.Int);
        public static readonly FunctionSymbol SetSize = new FunctionSymbol("SetSize", ImmutableArray.Create(new ParameterSymbol("X", TypeSymbol.Int, 0), new ParameterSymbol("Y", TypeSymbol.Int, 0)), TypeSymbol.Void);

        //Math
        public static readonly FunctionSymbol Random = new FunctionSymbol("Random", ImmutableArray.Create(new ParameterSymbol("max", TypeSymbol.Int, 0)), TypeSymbol.Int);

        //Other stuff
        public static readonly FunctionSymbol Version = new FunctionSymbol("Version", ImmutableArray<ParameterSymbol>.Empty, TypeSymbol.String);

        internal static IEnumerable<FunctionSymbol> GetAll()
            => typeof(BuiltinFunctions).GetFields(BindingFlags.Public | BindingFlags.Static)
                                       .Where(f => f.FieldType == typeof(FunctionSymbol))
                                       .Select(f => (FunctionSymbol)f.GetValue(null));
    }
}