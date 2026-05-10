using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class UISettingString : UISetting<string>
	{
		[InjectScope(EGetScope.Children)]
		[SerializeField]
		[Inject(false)]
		protected CTSToggle _toggle;
	}
}
