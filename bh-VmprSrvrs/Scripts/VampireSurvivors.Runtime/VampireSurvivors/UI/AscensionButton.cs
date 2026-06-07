using Coffee.UIExtensions;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using Zenject;

namespace VampireSurvivors.UI
{
	public class AscensionButton : MonoBehaviour
	{
		[SerializeField]
		private UIParticle _StarsBurstParticles;

		[SerializeField]
		private Transform _VFXTransform;

		[SerializeField]
		private Image _VFXBeam;

		[SerializeField]
		private Image _VFXsPFX_ring_64;

		[SerializeField]
		private bool _ForceShowAscensionConfirmation;

		private AdventureManager _adventureManager;

		private AdventureType _adventure;

		[Inject]
		private void Construct(AdventureManager adventure)
		{
		}

		private void Start()
		{
		}

		public void SetAdventure(AdventureType t)
		{
		}

		public void TryAscend()
		{
		}

		private void OnAscend(bool result)
		{
		}

		private void CreateAngelVFX()
		{
		}

		private void TestPFX()
		{
		}

		private void CreateParticles()
		{
		}
	}
}
