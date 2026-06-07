using System.Collections.Generic;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class ParticleSystemPooler
	{
		private List<ParticleSystem> activeList = new List<ParticleSystem>();

		private List<ParticleSystem> inactiveList = new List<ParticleSystem>();

		public ParticleSystemPooler(GameObject particlePrefab, Vector3 position, Quaternion rotation, int bufferLength)
		{
			for (int i = 0; i < bufferLength; i++)
			{
				ParticleSystem component = Object.Instantiate(particlePrefab, position, rotation).GetComponent<ParticleSystem>();
				ParticleSystem.MainModule main = component.main;
				main.playOnAwake = false;
				component.Stop(withChildren: true);
				if (component != null)
				{
					inactiveList.Add(component);
				}
			}
		}

		private ParticleSystem SelectParticle()
		{
			ParticleSystem particleSystem = null;
			if (inactiveList.Count == 0)
			{
				particleSystem = activeList[0];
			}
			else
			{
				particleSystem = inactiveList[0];
				inactiveList.RemoveAt(0);
				activeList.Add(particleSystem);
			}
			return particleSystem;
		}

		public void Instantiate(Vector3 position, Quaternion rotation)
		{
			ParticleSystem particleSystem = SelectParticle();
			particleSystem.transform.position = position;
			particleSystem.transform.rotation = rotation;
			particleSystem.Play(withChildren: true);
		}

		public void Instantiate(Vector3 position, Quaternion rotation, Color color)
		{
			ParticleSystem particleSystem = SelectParticle();
			ParticleSystem.MainModule main = particleSystem.main;
			particleSystem.transform.position = position;
			particleSystem.transform.rotation = rotation;
			Color color2 = main.startColor.color;
			color2.r = color.r;
			color2.g = color.g;
			color2.b = color.b;
			main.startColor = color2;
			particleSystem.Play(withChildren: true);
			activeList.Add(particleSystem);
		}

		public void Instantiate(Vector3 position, Quaternion rotation, Color color, float startSpeed)
		{
			ParticleSystem particleSystem = SelectParticle();
			ParticleSystem.MainModule main = particleSystem.main;
			particleSystem.transform.position = position;
			particleSystem.transform.rotation = rotation;
			Color color2 = main.startColor.color;
			color2.r = color.r;
			color2.g = color.g;
			color2.b = color.b;
			main.startColor = color2;
			main.startSpeed = startSpeed;
			particleSystem.Play(withChildren: true);
			activeList.Add(particleSystem);
		}

		public void Instantiate(Vector3 position, Quaternion rotation, Color color, float startSpeed, float startSize)
		{
			ParticleSystem particleSystem = SelectParticle();
			ParticleSystem.MainModule main = particleSystem.main;
			particleSystem.transform.position = position;
			particleSystem.transform.rotation = rotation;
			Color color2 = main.startColor.color;
			color2.r = color.r;
			color2.g = color.g;
			color2.b = color.b;
			main.startColor = color2;
			main.startSpeed = startSpeed;
			main.startSize = startSize;
			particleSystem.Play(withChildren: true);
			activeList.Add(particleSystem);
		}

		public void Update()
		{
			for (int num = activeList.Count - 1; num >= 0; num--)
			{
				ParticleSystem particleSystem = activeList[num];
				if (!particleSystem.isPlaying)
				{
					activeList.RemoveAt(num);
					inactiveList.Add(particleSystem);
				}
			}
		}
	}
}
