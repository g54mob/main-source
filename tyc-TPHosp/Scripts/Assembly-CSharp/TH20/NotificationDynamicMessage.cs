using System;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class NotificationDynamicMessage : NotificationGenericDecision
	{
		[DontSave]
		public Func<string> FuncGetTitle;

		[DontSave]
		public Func<string> FuncGetMessage;

		public NotificationDynamicMessage(NotificationMessages.Definition definition, ResponseDelegate responseDelegate, Level level)
			: base(definition, responseDelegate, level)
		{
		}

		public override string GetTitleText()
		{
			if (FuncGetTitle != null)
			{
				return FuncGetTitle();
			}
			return base.GetTitleText();
		}

		public override string GetMessageText()
		{
			if (FuncGetMessage != null)
			{
				return FuncGetMessage();
			}
			return base.GetMessageText();
		}
	}
}
