using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public abstract class CopyRunner<TValue> : TCopyRunner
	{
		private const HideFlags HIDE_FLAGS = HideFlags.DontSave | HideFlags.HideInHierarchy;

		[SerializeField]
		private TValue m_Runner;

		public static TCopy CreateTemplate<TCopy>(object runner) where TCopy : CopyRunner<TValue>
		{
			TCopy val = new GameObject
			{
				name = "Template",
				hideFlags = (HideFlags.DontSave | HideFlags.HideInHierarchy)
			}.AddComponent<TCopy>();
			val.m_Runner = (TValue)runner;
			return val;
		}

		public override T GetRunner<T>()
		{
			TValue runner = m_Runner;
			if (runner is T)
			{
				return (T)((((object)runner) is T) ? ((object)runner) : null);
			}
			return default(T);
		}

		public TCopy CreateRunner<TCopy>() where TCopy : CopyRunner<TValue>
		{
			return CreateRunner<TCopy>(Vector3.zero, Quaternion.identity, null);
		}

		public TCopy CreateRunner<TCopy>(Transform parent) where TCopy : CopyRunner<TValue>
		{
			return CreateRunner<TCopy>(Vector3.zero, Quaternion.identity, parent);
		}

		public TCopy CreateRunner<TCopy>(Vector3 position, Quaternion rotation, Transform parent) where TCopy : CopyRunner<TValue>
		{
			if (parent != null)
			{
				position = parent.position + position;
				rotation = parent.rotation * rotation;
			}
			GameObject obj = UnityEngine.Object.Instantiate(base.gameObject, position, rotation, parent);
			obj.hideFlags = HideFlags.DontSave | HideFlags.HideInHierarchy;
			return obj.GetComponent<TCopy>();
		}
	}
}
