using System;
using ReCT.CodeAnalysis.Symbols;

namespace ReCT.CodeAnalysis.Binding
{
    internal sealed class BoundAssignmentExpression : BoundExpression
    {
        public BoundAssignmentExpression(VariableSymbol variable, BoundExpression expression)
        {
            Variable = variable;
            Expression = expression;
        }
        public BoundAssignmentExpression(VariableSymbol variable, BoundExpression expression, BoundExpression index)
        {
            Variable = variable;
            Expression = expression;
            Index = index;
            isArray = true;
        }

        public override BoundNodeKind Kind => BoundNodeKind.AssignmentExpression;
        public override TypeSymbol Type => Expression.Type;
        public VariableSymbol Variable { get; }
        public BoundExpression Expression { get; }
        public BoundExpression Index { get; }
        public bool isArray { get; }
    }
}
