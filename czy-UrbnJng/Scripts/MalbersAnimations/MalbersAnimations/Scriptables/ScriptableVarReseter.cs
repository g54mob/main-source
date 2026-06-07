using System;

namespace MalbersAnimations.Scriptables
{
	[Serializable]
	public struct ScriptableVarReseter
	{
		public ScriptableVar Var;

		public BoolReference DefaultBool;

		public IntReference DefaultInt;

		public FloatReference DefaultFloat;

		public StringReference DefaultString;

		public Vector2Reference DefaultVector2;

		public Vector3Reference DefaultVector3;

		public ColorReference DefaultColor;

		public TransformReference DefaultTransform;

		public GameObjectReference DefaultGO;

		public void ResetVar()
		{
			if (Var is IntVar)
			{
				(Var as IntVar).Value = DefaultInt.Value;
			}
			else if (Var is BoolVar)
			{
				(Var as BoolVar).Value = DefaultBool.Value;
			}
			else if (Var is FloatVar)
			{
				(Var as FloatVar).Value = DefaultFloat.Value;
			}
			else if (Var is StringVar)
			{
				(Var as StringVar).Value = DefaultString.Value;
			}
			else if (Var is Vector3Var)
			{
				(Var as Vector3Var).Value = DefaultVector3.Value;
			}
			else if (Var is Vector2Var)
			{
				(Var as Vector2Var).Value = DefaultVector2.Value;
			}
			else if (Var is ColorVar)
			{
				(Var as ColorVar).Value = DefaultColor.Value;
			}
			else if (Var is TransformVar)
			{
				(Var as TransformVar).Value = DefaultTransform.Value;
			}
			else if (Var is GameObjectVar)
			{
				(Var as GameObjectVar).Value = DefaultGO.Value;
			}
		}
	}
}
