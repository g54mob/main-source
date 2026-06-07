using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[AddComponentMenu("")]
	[DisallowMultipleComponent]
	public class StagingGizmos : MonoBehaviour
	{
		[NonSerialized]
		private ScriptableObject m_Asset;

		[NonSerialized]
		private IStageGizmos m_Gizmos;

		public Animator Animator => GetComponentInChildren<Animator>();

		public static StagingGizmos Bind<T>(GameObject target, T asset) where T : ScriptableObject, IStageGizmos
		{
			StagingGizmos stagingGizmos = target.AddComponent<StagingGizmos>();
			stagingGizmos.m_Asset = asset;
			stagingGizmos.m_Gizmos = asset;
			stagingGizmos.hideFlags = HideFlags.DontSave;
			return stagingGizmos;
		}

		public static S Bind<T, S>(GameObject target, T asset) where T : ScriptableObject, IStageGizmos where S : StagingGizmos
		{
			S val = target.AddComponent<S>();
			val.m_Asset = asset;
			val.m_Gizmos = asset;
			val.hideFlags = HideFlags.DontSave;
			return val;
		}

		public void SelectAsset()
		{
		}

		private T GetAsset<T>() where T : ScriptableObject
		{
			return m_Asset as T;
		}
	}
}
