using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.BladedEngineScripts.Utils
{
	public class ReparentUtil : MonoBehaviour
	{
		[SerializeField]
		private bool _dieWithOriginalParent = true;

		[SerializeField]
		private Transform _targetParent;

		public void Reparent()
		{
			if (_dieWithOriginalParent)
			{
				ExecuteOnUnityAction executeOnUnityAction = base.transform.parent.gameObject.AddComponent<ExecuteOnUnityAction>();
				GameObject myGo = base.gameObject;
				executeOnUnityAction.Destroyed += delegate
				{
					Object.Destroy(myGo);
				};
			}
			base.transform.parent = _targetParent;
			Object.Destroy(this);
		}
	}
}
