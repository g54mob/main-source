using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace CTS.Core
{
	[CustomInjector(typeof(List<>))]
	public class ListInjector<T> : IInjector
	{
		private T[] _dummyArray;

		private readonly FieldInfo _arrayField = typeof(ListInjector<T>).GetField("_dummyArray", BindingFlags.Instance | BindingFlags.NonPublic);

		private readonly IInjector _subInjector = TypeInjector.GetInjector(typeof(T));

		void IInjector.InjectSingle(MonoBehaviour sceneTarget, object fieldTarget, FieldInfo field, EGetScope scope, bool forceReplace)
		{
			if (forceReplace || !(field.GetValue(fieldTarget) is List<T> { Count: >0 }))
			{
				_dummyArray = null;
				_subInjector.InjectArray(sceneTarget, this, _arrayField, scope, forceReplace: true);
				field.SetValue(sceneTarget, _dummyArray?.ToList());
			}
		}

		void IInjector.InjectArray(MonoBehaviour sceneTarget, object fieldTarget, FieldInfo field, EGetScope scope, bool forceReplace)
		{
		}
	}
}
