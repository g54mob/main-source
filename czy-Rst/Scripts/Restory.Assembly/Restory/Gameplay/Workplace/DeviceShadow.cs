using System;
using Restory.Constants;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Zenject;

namespace Restory.Gameplay.Workplace
{
	public class DeviceShadow : MonoBehaviour, IInitializable, IDisposable
	{
		[SerializeField]
		private DecalProjector decalProjector;

		[SerializeField]
		private Color defaultShadowColor;

		[SerializeField]
		private Color competitionShadowColor;

		private Material decalMaterialInstance;

		public void Initialize()
		{
			if (!decalMaterialInstance)
			{
				decalMaterialInstance = new Material(decalProjector.material);
				decalProjector.material = decalMaterialInstance;
			}
		}

		public void Dispose()
		{
			if ((bool)decalMaterialInstance)
			{
				UnityEngine.Object.Destroy(decalMaterialInstance);
			}
		}

		public void SetDefaultDeviceShadow()
		{
			ChangeDecalColor(defaultShadowColor);
		}

		public void SetCompetitionDeviceShadow()
		{
			ChangeDecalColor(competitionShadowColor);
		}

		private void ChangeDecalColor(Color newColor)
		{
			if (decalMaterialInstance != null)
			{
				decalMaterialInstance.SetColor(ProjectConstants.MaterialProperties.Color, newColor);
			}
		}
	}
}
