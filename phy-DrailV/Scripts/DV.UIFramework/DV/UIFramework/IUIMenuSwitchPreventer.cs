using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DV.UIFramework
{
	public interface IUIMenuSwitchPreventer
	{
		UniTask RequestSwitch();

		GameObject GetGameObject();
	}
}
