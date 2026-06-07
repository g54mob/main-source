using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Effects - Audio/Effect Manager")]
	public class EffectManager : MonoBehaviour, IAnimatorListener
	{
		[RequiredField]
		[Tooltip("Root Gameobject of the Hierarchy")]
		public Transform Owner;

		public List<Effect> Effects;

		public int SelectedEffect = -1;

		public bool debug;

		private Effect Pin_Effect;

		Transform IAnimatorListener.transform => base.transform;

		private void Awake()
		{
			foreach (Effect effect in Effects)
			{
				effect.Initialize();
			}
		}

		private void OnDisable()
		{
			Stop_Effects(Effects);
		}

		public virtual void PlayEffect(int ID)
		{
			List<Effect> list = Effects.FindAll((Effect effect) => effect.ID == ID && effect.active);
			if (list == null)
			{
				return;
			}
			foreach (Effect item in list)
			{
				Play(item);
			}
		}

		public virtual void Effect_Pin(string name)
		{
			Pin_Effect = Effects.Find((Effect effect) => effect.Name == name && effect.active);
		}

		public virtual void Effect_Pin(int ID)
		{
			Pin_Effect = Effects.Find((Effect effect) => effect.ID == ID && effect.active);
		}

		public virtual void Effect_Pin_Root(Transform root)
		{
			Pin_Effect.root = root;
		}

		public virtual void PlayEffect(string name)
		{
			List<Effect> list = Effects.FindAll((Effect effect) => effect.Name == name && effect.active);
			if (list == null)
			{
				return;
			}
			foreach (Effect item in list)
			{
				Play(item);
			}
		}

		public virtual void StopEffect(string name)
		{
			List<Effect> effects = Effects.FindAll((Effect effect) => effect.Name == name && effect.active);
			Stop_Effects(effects);
		}

		public virtual void StopEffect(int ID)
		{
			Effect_Stop(ID);
		}

		public virtual void Effect_Play(int ID)
		{
			PlayEffect(ID);
		}

		public virtual void EffectPlay(int ID)
		{
			PlayEffect(ID);
		}

		public virtual void Effect_Play(string name)
		{
			PlayEffect(name);
		}

		public virtual void EffectPlay(string name)
		{
			PlayEffect(name);
		}

		public virtual void Effect_Stop(int ID)
		{
			List<Effect> effects = Effects.FindAll((Effect effect) => effect.ID == ID && effect.active);
			Stop_Effects(effects);
		}

		private void Stop_Effects(List<Effect> effects)
		{
			if (effects == null)
			{
				return;
			}
			foreach (Effect effect in effects)
			{
				StopEffect(effect, effect.Instance);
			}
		}

		public virtual void StopEffect(Effect e, GameObject instance)
		{
			if (!e.IsPlaying)
			{
				return;
			}
			e.OnStopReaction?.React(Owner);
			e.OnStop.Invoke();
			e.IsPlaying = false;
			if (e.effect != null)
			{
				if (!e.effect.IsPrefab())
				{
					if (e.disableOnStop)
					{
						instance?.SetActive(value: false);
					}
				}
				else
				{
					Object.Destroy(instance);
				}
			}
			if (debug)
			{
				Debug.Log("<B>" + Owner.name + "</B> Effect Stop: <B>[" + e.Name + "]</B>", (instance != null) ? ((Object)instance) : ((Object)this));
			}
		}

		public virtual void Effect_Stop(string name)
		{
			List<Effect> effects = Effects.FindAll((Effect effect) => effect.Name == name && effect.active);
			Stop_Effects(effects);
		}

		protected virtual void Play(Effect e)
		{
			if (e.effect != null && e.IsPlaying)
			{
				return;
			}
			this.Delay_Action(e.delay, delegate
			{
				e.IsPlaying = true;
				if (!e.Clip.NullOrEmpty() && e.audioSource != null)
				{
					if (e.audioSource.isPlaying)
					{
						e.audioSource.Stop();
					}
					e.Clip.Play(e.audioSource);
				}
				if (e.effect != null)
				{
					if (e.effect.IsPrefab())
					{
						e.Instance = Object.Instantiate(e.effect);
						e.Instance.SetActive(value: false);
						e.Instance.transform.localScale *= e.scale;
					}
					else
					{
						e.Instance = e.effect;
					}
					if (Owner == null)
					{
						Owner = base.transform.root;
					}
					if (e.Owner == null)
					{
						e.Owner = Owner;
					}
					if ((bool)e.Instance)
					{
						if ((bool)e.root)
						{
							e.Instance.transform.position = e.root.position;
							if (e.isChild)
							{
								e.Instance.transform.parent = e.root;
								e.Offset.RestoreTransform(e.Instance.transform);
							}
							else
							{
								e.Instance.transform.position = e.root.TransformPoint(e.Offset.Position);
							}
							if (e.useRootRotation)
							{
								e.Instance.transform.rotation = e.root.rotation * Quaternion.Euler(e.Offset.Rotation);
							}
						}
						e.Instance.SetActive(value: true);
						if (e.effect.IsPrefab())
						{
							e.IsTrailRenderer = e.Instance.FindComponent<TrailRenderer>();
							e.IsParticleSystem = e.Instance.FindComponent<ParticleSystem>();
						}
						if ((bool)e.IsTrailRenderer)
						{
							e.IsTrailRenderer.Clear();
						}
						if ((bool)e.IsParticleSystem)
						{
							e.IsParticleSystem.Play();
						}
					}
				}
				if (e.life > 0f)
				{
					this.Delay_Action(e.life, delegate
					{
						StopEffect(e, e.Instance);
					});
				}
				if (debug)
				{
					Debug.Log("<B>" + Owner.name + "</B> Effect Play: <B>[" + e.Name + "]</B>", (e.Instance != null) ? ((Object)e.Instance) : ((Object)this));
				}
				e.OnPlay.Invoke();
				e.OnPlayReaction?.React(Owner);
			});
		}

		public virtual bool OnAnimatorBehaviourMessage(string message, object value)
		{
			return this.InvokeWithParams(message, value);
		}

		public virtual void Effect_Disable(string name)
		{
			List<Effect> list = Effects.FindAll((Effect effect) => effect.Name.ToUpper() == name.ToUpper());
			if (list != null)
			{
				foreach (Effect item in list)
				{
					item.active = false;
				}
				return;
			}
			Debug.LogWarning("No effect with the name: " + name + " was found");
		}

		public virtual void Effect_Disable(int ID)
		{
			List<Effect> list = Effects.FindAll((Effect effect) => effect.ID == ID);
			if (list != null)
			{
				foreach (Effect item in list)
				{
					item.active = false;
				}
				return;
			}
			Debug.LogWarning("No effect with the ID: " + ID + " was found");
		}

		public virtual void Effect_Enable(string name)
		{
			List<Effect> list = Effects.FindAll((Effect effect) => effect.Name.ToUpper() == name.ToUpper());
			if (list != null)
			{
				foreach (Effect item in list)
				{
					item.active = true;
				}
				return;
			}
			Debug.LogWarning("No effect with the name: " + name + " was found");
		}

		public virtual void Effect_Enable(int ID)
		{
			List<Effect> list = Effects.FindAll((Effect effect) => effect.ID == ID);
			if (list != null)
			{
				foreach (Effect item in list)
				{
					item.active = true;
				}
				return;
			}
			Debug.LogWarning("No effect with the ID: " + ID + " was found");
		}

		private void Reset()
		{
			Owner = base.transform.root;
		}
	}
}
