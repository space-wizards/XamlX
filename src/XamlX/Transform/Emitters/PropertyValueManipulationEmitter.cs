using System.Reflection.Emit;
using XamlX.Ast;
using XamlX.TypeSystem;

namespace XamlX.Transform.Emitters
{
    public class PropertyValueManipulationEmitter : IXamlXAstNodeEmitter
    {
        public XamlXNodeEmitResult Emit(IXamlXAstNode node, XamlXEmitContext context, IXamlXEmitter codeGen)
        {
            if (!(node is XamlXPropertyValueManipulationNode pvm))
                return null;
            codeGen.Emit(pvm.Property.Getter.IsStatic ? OpCodes.Call : OpCodes.Callvirt,
                pvm.Property.Getter);
            context.Emit(pvm.Manipulation, codeGen, null);
            
            return XamlXNodeEmitResult.Void;
        }
    }
}