using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rhizomatic.MemberBinding
{
	public class MemberBinder : MonoBehaviour, IMemberBinderContext
	{
		public bool bindOnAwake;

		public MonoBehaviour target;

		public static Dictionary<Type, MemberBindData> bindData;

		private bool hasBind;

		private void Awake()
		{
		}

		public void ForceBind()
		{
		}

		public static MemberBindData GetBindData(Type type)
		{
			return null;
		}

		public void Bind()
		{
		}

		public static Dictionary<string, List<GameObject>> GetAllChildren(Transform transform)
		{
			return null;
		}

		public static string GetObjectName(GameObject obj)
		{
			return null;
		}

		private void Reset()
		{
		}

		public void FetchTarget()
		{
		}

		public static string GetLabelName(string val)
		{
			return null;
		}

		public static void Bind(MonoBehaviour target)
		{
		}

		public static void Bind(GameObject target)
		{
		}

		public static void ForceBind(MonoBehaviour target)
		{
		}

		public static void ForceBind(GameObject target)
		{
		}
	}
}
