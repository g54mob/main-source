using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class ValidateInputAttribute : Attribute
	{
		public string DefaultMessage;

		public string Condition;

		public InfoMessageType MessageType;

		public bool IncludeChildren;

		[LabelWidth(170f)]
		public bool ContinuousValidationCheck;

		[Obsolete("Use the Condition member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
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

		[Obsolete("Use the ContinuousValidationCheck member instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
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

		[Obsolete("Rejecting invalid input is no longer supported. Use the other constructor instead.", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ValidateInputAttribute(string condition, string message, InfoMessageType messageType, bool rejectedInvalidInput)
		{
		}
	}
}
