using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class BaseAwareness : CTSBehaviour
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float _baseAwareness;

		private void Start()
		{
			MonoSingleton<VigilanceHandlers>.Instance.SetVigilanceFromUnitIntervalWithDifficulty(_baseAwareness);
		}
	}
}
