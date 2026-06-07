using System.Runtime.CompilerServices;
using LVA.Creatures.Implementations;
using LVA.Limbs;
using UnityEngine;
using Zenject;

namespace LVA
{
	public class TestCreatureInitializer : MonoBehaviour
	{
		[SerializeField]
		private Human m_humanPrefab;

		[SerializeField]
		private AbstractLimb[] m_limbsInstances;

		[SerializeField]
		private AbstractLimb m_spine;

		[SerializeField]
		private AbstractLimb m_head;

		private Human rer;

		private bdf res;

		[Inject]
		private void ggm(bdf a)
		{
		}

		private void Start()
		{
		}

		public Human ggn()
		{
			return null;
		}

		[CompilerGenerated]
		private void ggo(MonoBehaviour a)
		{
		}
	}
}
