using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HideBackPieceGameObjectComponent : MonoBehaviour
	{
		private void Awake()
		{
			float num = ((Time.timeScale > 0f) ? Time.timeScale : 1f);
			Object.Destroy(this, 2f * num);
		}

		private void OnDestroy()
		{
			GameObjectUtils.SetActive(base.gameObject, isActive: false);
		}
	}
}
