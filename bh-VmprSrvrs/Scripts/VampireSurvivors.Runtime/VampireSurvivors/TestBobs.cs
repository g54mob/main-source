using UnityEngine;
using VampireSurvivors.Graphics.Blitters;

namespace VampireSurvivors
{
	public class TestBobs : MonoBehaviour
	{
		[SerializeField]
		protected int count;

		[SerializeField]
		private Sprite sprite;

		[SerializeField]
		protected Vector2 spawnRange;

		private Blitter _blitter;

		protected void Start()
		{
		}

		protected void OnDestroy()
		{
		}
	}
}
