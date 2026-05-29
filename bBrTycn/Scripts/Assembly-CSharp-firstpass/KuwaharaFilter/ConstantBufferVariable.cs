using UnityEngine;

namespace KuwaharaFilter
{
	public class ConstantBufferVariable
	{
		public int GaussRadius;

		public int KuwaharaRadius;

		public int KuwaharaQ;

		public float KuwaharaAlpha;

		public static void Apply(ComputeShader shader, ConstantBufferVariable buffer)
		{
			shader.SetInt("GaussRadius", buffer.GaussRadius);
			shader.SetInt("KuwaharaRadius", buffer.KuwaharaRadius);
			shader.SetInt("KuwaharaQ", buffer.KuwaharaQ);
			shader.SetFloat("KuwaharaAlpha", buffer.KuwaharaAlpha);
		}
	}
}
