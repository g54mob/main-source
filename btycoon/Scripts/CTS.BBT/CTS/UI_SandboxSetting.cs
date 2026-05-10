using CTS.Core;
using UnityEngine;

namespace CTS
{
	public abstract class UI_SandboxSetting<TObject, TValue> : CTSBehaviour, IResettableSetting where TObject : ScriptableObject
	{
		[InjectScope(EGetScope.Parent)]
		[SerializeField]
		[Inject(false)]
		protected UI_SandboxProfileCreator _profileCreator;

		protected virtual void Start()
		{
			ResetValue();
		}

		protected abstract TObject GetObject();

		protected abstract TValue GetValue(TObject obj);

		protected abstract void SetValue(TObject obj, TValue value);

		public abstract void ResetValue();
	}
}
