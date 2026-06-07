using System;

namespace UI.Xml
{
	public abstract class XmlLayoutControllerMVVM : XmlLayoutController
	{
		public abstract void SetViewModelValue(string memberName, object newValue, bool fromTwoWayBinding = false);

		public abstract Type GetViewModelMemberDataType(string memberName);

		public abstract void SetViewModelListItemValue(string listName, int index, string memberName, object newValue, bool fromTwoWayBinding = false);
	}
}
