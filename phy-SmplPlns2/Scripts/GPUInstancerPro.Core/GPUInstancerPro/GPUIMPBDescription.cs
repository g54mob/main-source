using UnityEngine;

namespace GPUInstancerPro
{
	public abstract class GPUIMPBDescription : ScriptableObject
	{
		public Shader shader;

		public abstract void SetMPBValues(GPUIRenderSourceGroup rsg, GPUIManager manager, int prototypeIndex);
	}
}
