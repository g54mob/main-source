using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.BladedEngineScripts.Utils
{
	public class WorldScaleStaysScript : MonoBehaviour
	{
		private Vector3 _worldScale;

		public void ResetWorldScale()
		{
			base.transform.localScale = Vector3.one;
			Vector3 lossyScale = base.transform.lossyScale;
			base.transform.localScale = new Vector3(_worldScale.x / lossyScale.x, _worldScale.y / lossyScale.y, _worldScale.z / lossyScale.z);
		}

		protected virtual void Awake()
		{
			_worldScale = base.transform.lossyScale;
		}
	}
}
