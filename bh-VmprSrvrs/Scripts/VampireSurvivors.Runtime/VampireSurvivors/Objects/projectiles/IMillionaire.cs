using UnityEngine;

namespace VampireSurvivors.Objects.Projectiles
{
	internal interface IMillionaire
	{
		void Millionaire(float x, float y, float angle, int times = 4);

		void FireVolley(Vector2 pos, int _amount, Transform target = null);
	}
}
