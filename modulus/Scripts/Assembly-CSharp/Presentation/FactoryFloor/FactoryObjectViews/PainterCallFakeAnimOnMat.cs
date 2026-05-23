using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews
{
	public class PainterCallFakeAnimOnMat : CallFakeAnimOnMaterial
	{
		private static readonly int GoUp = Shader.PropertyToID("_goUp");

		private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");

		public void SetGoingUp(bool goUp)
		{
			if (!_initialized)
			{
				Init();
			}
			_instancedMat.SetFloat(GoUp, goUp ? 1f : 0f);
		}

		public void SetColor(Color color)
		{
			if (!_initialized)
			{
				Init();
			}
			_instancedMat.SetColor(BaseColor, color);
		}
	}
}
