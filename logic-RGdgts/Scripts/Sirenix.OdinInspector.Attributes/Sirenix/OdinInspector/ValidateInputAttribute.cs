using System;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	public sealed class ValidateInputAttribute : Attribute
	{
		public string DefaultMessage;

		public string Condition;

		public InfoMessageType MessageType;

		public bool IncludeChildren;

		public bool ContinuousValidationCheck;

		[Obsolete]
		public string MemberName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete]
		public bool ContiniousValidationCheck
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public ValidateInputAttribute(string condition, string defaultMessage = null, InfoMessageType messageType = InfoMessageType.Error)
		{
		}

		[Obsolete]
		public ValidateInputAttribute(string condition, string message, InfoMessageType messageType, bool rejectedInvalidInput)
		{
		}
	}
}
