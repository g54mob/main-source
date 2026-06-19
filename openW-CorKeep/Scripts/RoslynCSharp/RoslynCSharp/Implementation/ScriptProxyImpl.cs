using System;
using UnityEngine;

namespace RoslynCSharp.Implementation
{
	internal sealed class ScriptProxyImpl : ScriptProxy
	{
		private ScriptType scriptType;

		private object instance;

		public override ScriptAssembly Assembly
		{
			get
			{
				CheckDisposed();
				return scriptType.Assembly;
			}
		}

		public override ScriptType ScriptType
		{
			get
			{
				CheckDisposed();
				return scriptType;
			}
		}

		public override object Instance
		{
			get
			{
				CheckDisposed();
				return instance;
			}
		}

		public override bool IsDisposed => instance == null;

		protected override void ConstructInstance(ScriptType type, object instance)
		{
			scriptType = type;
			this.instance = instance;
		}

		public override void Dispose()
		{
			CheckDisposed();
			if (IsUnityObject)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(UnityInstance);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(UnityInstance, allowDestroyingAssets: false);
				}
			}
			if (instance is IDisposable)
			{
				(instance as IDisposable).Dispose();
			}
			scriptType = null;
			instance = null;
		}
	}
}
