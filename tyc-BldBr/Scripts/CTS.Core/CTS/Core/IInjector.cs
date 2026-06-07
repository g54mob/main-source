using System.Reflection;
using UnityEngine;

namespace CTS.Core
{
	public interface IInjector
	{
		internal void InjectSingle(MonoBehaviour sceneTarget, object fieldTarget, FieldInfo field, EGetScope scope, bool forceReplace);

		internal void InjectArray(MonoBehaviour sceneTarget, object fieldTarget, FieldInfo field, EGetScope scope, bool forceReplace);
	}
}
