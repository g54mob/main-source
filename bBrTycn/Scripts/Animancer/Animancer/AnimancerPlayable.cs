using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Animancer
{
	public class AnimancerPlayable : PlayableBehaviour, IEnumerator, IPlayableWrapper, IAnimationClipCollection
	{
		private class PostUpdate : PlayableBehaviour
		{
			private static readonly PostUpdate Template = new PostUpdate();

			private AnimancerPlayable _Root;

			private Playable _Playable;

			private bool _IsConnected;

			public bool IsConnected
			{
				get
				{
					return _IsConnected;
				}
				set
				{
					if (value)
					{
						if (!_IsConnected)
						{
							_IsConnected = true;
							_Root._Graph.Connect(_Playable, 0, _Root._RootPlayable, 1);
						}
					}
					else if (_IsConnected)
					{
						_IsConnected = false;
						_Root._Graph.Disconnect(_Root._RootPlayable, 1);
					}
				}
			}

			public static PostUpdate Create(AnimancerPlayable root)
			{
				PostUpdate behaviour = ScriptPlayable<PostUpdate>.Create(root._Graph, Template).GetBehaviour();
				behaviour._Root = root;
				return behaviour;
			}

			public override void OnPlayableCreate(Playable playable)
			{
				_Playable = playable;
			}

			public override void PrepareFrame(Playable playable, FrameData info)
			{
				_Root.UpdateAll(_Root._PostUpdatables, info.deltaTime * info.effectiveParentSpeed);
			}
		}

		public class LayerList : IEnumerable<AnimancerLayer>, IEnumerable, IAnimationClipCollection
		{
			protected readonly AnimancerPlayable Root;

			private AnimancerLayer[] _Layers;

			protected readonly AnimationLayerMixerPlayable LayerMixer;

			private int _Count;

			public int Count
			{
				get
				{
					return _Count;
				}
				set
				{
					int i = _Count;
					if (value == i)
					{
						return;
					}
					for (; value > i; i++)
					{
						Add();
					}
					while (value < i--)
					{
						AnimancerLayer animancerLayer = _Layers[i];
						if (animancerLayer._Playable.IsValid())
						{
							Root._Graph.DestroySubgraph(animancerLayer._Playable);
						}
						animancerLayer.DestroyStates();
					}
					Array.Clear(_Layers, value, _Count - value);
					_Count = value;
					Root._LayerMixer.SetInputCount(value);
				}
			}

			public static int DefaultCapacity { get; set; } = 4;

			public int Capacity
			{
				get
				{
					return _Layers.Length;
				}
				set
				{
					if (value <= 0)
					{
						throw new ArgumentOutOfRangeException("value", $"must be greater than 0 ({value} <= 0)");
					}
					if (_Count > value)
					{
						Count = value;
					}
					Array.Resize(ref _Layers, value);
				}
			}

			public AnimancerLayer this[int index]
			{
				get
				{
					SetMinCount(index + 1);
					return _Layers[index];
				}
			}

			public Vector3 AverageVelocity
			{
				get
				{
					Vector3 result = default(Vector3);
					for (int i = 0; i < _Count; i++)
					{
						AnimancerLayer animancerLayer = _Layers[i];
						result += animancerLayer.AverageVelocity * animancerLayer.Weight;
					}
					return result;
				}
			}

			protected LayerList(AnimancerPlayable root)
			{
				Root = root;
				_Layers = new AnimancerLayer[DefaultCapacity];
			}

			internal LayerList(AnimancerPlayable root, out Playable layerMixer)
				: this(root)
			{
				layerMixer = (LayerMixer = AnimationLayerMixerPlayable.Create(root._Graph, 1));
				Root._Graph.Connect(layerMixer, 0, Root._RootPlayable, 0);
			}

			public virtual void Activate(AnimancerPlayable root)
			{
				Activate(root, LayerMixer);
			}

			protected void Activate(AnimancerPlayable root, Playable mixer)
			{
				_Layers = root.Layers._Layers;
				_Count = root.Layers._Count;
				root._RootPlayable.DisconnectInput(0);
				root.Graph.Connect(mixer, 0, root._RootPlayable, 0);
				root.Layers = this;
				root._LayerMixer = mixer;
			}

			public void SetMinCount(int min)
			{
				if (Count < min)
				{
					Count = min;
				}
			}

			public static void SetMinDefaultCapacity(int min)
			{
				if (DefaultCapacity < min)
				{
					DefaultCapacity = min;
				}
			}

			public AnimancerLayer Add()
			{
				int count = _Count;
				if (count >= _Layers.Length)
				{
					Capacity *= 2;
				}
				_Count = count + 1;
				Root._LayerMixer.SetInputCount(_Count);
				AnimancerLayer animancerLayer = new AnimancerLayer(Root, count);
				_Layers[count] = animancerLayer;
				return animancerLayer;
			}

			public AnimancerLayer GetLayer(int index)
			{
				return _Layers[index];
			}

			public FastEnumerator<AnimancerLayer> GetEnumerator()
			{
				return new FastEnumerator<AnimancerLayer>(_Layers, _Count);
			}

			IEnumerator<AnimancerLayer> IEnumerable<AnimancerLayer>.GetEnumerator()
			{
				return GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			public void GatherAnimationClips(ICollection<AnimationClip> clips)
			{
				clips.GatherFromSource(_Layers);
			}

			public virtual bool IsAdditive(int index)
			{
				return LayerMixer.IsLayerAdditive((uint)index);
			}

			public virtual void SetAdditive(int index, bool value)
			{
				SetMinCount(index + 1);
				LayerMixer.SetLayerAdditive((uint)index, value);
			}

			public virtual void SetMask(int index, AvatarMask mask)
			{
				SetMinCount(index + 1);
				if (mask == null)
				{
					mask = new AvatarMask();
				}
				LayerMixer.SetLayerMaskFromAvatarMask((uint)index, mask);
			}

			[Conditional("UNITY_EDITOR")]
			public void SetDebugName(int index, string name)
			{
			}
		}

		public class StateDictionary : IEnumerable<AnimancerState>, IEnumerable, IAnimationClipCollection
		{
			private readonly AnimancerPlayable Root;

			private readonly Dictionary<object, AnimancerState> States = new Dictionary<object, AnimancerState>(EqualityComparer);

			public static IEqualityComparer<object> EqualityComparer { get; set; } = FastComparer.Instance;

			public int Count => States.Count;

			public AnimancerState Current => Root.Layers[0].CurrentState;

			public AnimancerState this[AnimationClip clip] => States[Root.GetKey(clip)];

			public AnimancerState this[IHasKey hasKey] => States[hasKey.Key];

			public AnimancerState this[object key] => States[key];

			internal StateDictionary(AnimancerPlayable root)
			{
				Root = root;
			}

			public ClipState Create(AnimationClip clip)
			{
				return Create(Root.GetKey(clip), clip);
			}

			public ClipState Create(object key, AnimationClip clip)
			{
				ClipState clipState = new ClipState(clip);
				clipState.SetRoot(Root);
				clipState._Key = key;
				Register(clipState);
				return clipState;
			}

			public void CreateIfNew(AnimationClip clip0, AnimationClip clip1)
			{
				GetOrCreate(clip0);
				GetOrCreate(clip1);
			}

			public void CreateIfNew(AnimationClip clip0, AnimationClip clip1, AnimationClip clip2)
			{
				GetOrCreate(clip0);
				GetOrCreate(clip1);
				GetOrCreate(clip2);
			}

			public void CreateIfNew(AnimationClip clip0, AnimationClip clip1, AnimationClip clip2, AnimationClip clip3)
			{
				GetOrCreate(clip0);
				GetOrCreate(clip1);
				GetOrCreate(clip2);
				GetOrCreate(clip3);
			}

			public void CreateIfNew(params AnimationClip[] clips)
			{
				if (clips == null)
				{
					return;
				}
				int num = clips.Length;
				for (int i = 0; i < num; i++)
				{
					AnimationClip animationClip = clips[i];
					if (animationClip != null)
					{
						GetOrCreate(animationClip);
					}
				}
			}

			public bool TryGet(AnimationClip clip, out AnimancerState state)
			{
				if (clip == null)
				{
					state = null;
					return false;
				}
				return TryGet(Root.GetKey(clip), out state);
			}

			public bool TryGet(IHasKey hasKey, out AnimancerState state)
			{
				if (hasKey == null)
				{
					state = null;
					return false;
				}
				return TryGet(hasKey.Key, out state);
			}

			public bool TryGet(object key, out AnimancerState state)
			{
				if (key == null)
				{
					state = null;
					return false;
				}
				return States.TryGetValue(key, out state);
			}

			public AnimancerState GetOrCreate(AnimationClip clip, bool allowSetClip = false)
			{
				return GetOrCreate(Root.GetKey(clip), clip, allowSetClip);
			}

			public AnimancerState GetOrCreate(ITransition transition)
			{
				object key = transition.Key;
				if (!TryGet(key, out var state))
				{
					state = transition.CreateState();
					state.SetRoot(Root);
					state._Key = key;
					Register(state);
				}
				return state;
			}

			public AnimancerState GetOrCreate(object key, AnimationClip clip, bool allowSetClip = false)
			{
				if (TryGet(key, out var state))
				{
					if ((object)state.Clip != clip)
					{
						if (!allowSetClip)
						{
							throw new ArgumentException(GetClipMismatchError(key, state.Clip, clip));
						}
						state.Clip = clip;
					}
					return state;
				}
				return Create(key, clip);
			}

			public static string GetClipMismatchError(object key, AnimationClip oldClip, AnimationClip newClip)
			{
				return "A state already exists using the specified 'key', but has a different AnimationClip:" + $"\n• Key: {key}" + $"\n• Old Clip: {oldClip}" + $"\n• New Clip: {newClip}";
			}

			internal void Register(AnimancerState state)
			{
				object key = state._Key;
				if (key != null)
				{
					States.Add(key, state);
				}
			}

			internal void Unregister(AnimancerState state)
			{
				object key = state._Key;
				if (key != null)
				{
					States.Remove(key);
				}
			}

			public Dictionary<object, AnimancerState>.ValueCollection.Enumerator GetEnumerator()
			{
				return States.Values.GetEnumerator();
			}

			IEnumerator<AnimancerState> IEnumerable<AnimancerState>.GetEnumerator()
			{
				return GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			public void GatherAnimationClips(ICollection<AnimationClip> clips)
			{
				foreach (AnimancerState value in States.Values)
				{
					clips.GatherFromSource(value);
				}
			}

			public bool Destroy(AnimationClip clip)
			{
				if (clip == null)
				{
					return false;
				}
				return Destroy(Root.GetKey(clip));
			}

			public bool Destroy(IHasKey hasKey)
			{
				if (hasKey == null)
				{
					return false;
				}
				return Destroy(hasKey.Key);
			}

			public bool Destroy(object key)
			{
				if (!TryGet(key, out var state))
				{
					return false;
				}
				state.Destroy();
				return true;
			}

			public void DestroyAll(IList<AnimationClip> clips)
			{
				if (clips != null)
				{
					for (int num = clips.Count - 1; num >= 0; num--)
					{
						Destroy(clips[num]);
					}
				}
			}

			public void DestroyAll(IEnumerable<AnimationClip> clips)
			{
				if (clips == null)
				{
					return;
				}
				foreach (AnimationClip clip in clips)
				{
					Destroy(clip);
				}
			}

			public void DestroyAll(IAnimationClipSource source)
			{
				if (source != null)
				{
					List<AnimationClip> list = ObjectPool.AcquireList<AnimationClip>();
					source.GetAnimationClips(list);
					DestroyAll(list);
					ObjectPool.Release(list);
				}
			}

			public void DestroyAll(IAnimationClipCollection source)
			{
				if (source != null)
				{
					HashSet<AnimationClip> hashSet = ObjectPool.AcquireSet<AnimationClip>();
					source.GatherAnimationClips(hashSet);
					DestroyAll(hashSet);
					ObjectPool.Release(hashSet);
				}
			}
		}

		private static float _DefaultFadeDuration = 0.25f;

		internal PlayableGraph _Graph;

		internal Playable _RootPlayable;

		internal Playable _LayerMixer;

		private Key.KeyedList<IUpdatable> _PreUpdatables;

		private Key.KeyedList<IUpdatable> _PostUpdatables;

		private PostUpdate _PostUpdate;

		private float _Speed = 1f;

		private bool _KeepChildrenConnected;

		private bool _SkipFirstFade;

		private static readonly AnimancerPlayable Template = new AnimancerPlayable();

		private List<IDisposable> _Disposables;

		private bool _ApplyAnimatorIK;

		private bool _ApplyFootIK;

		private bool _IsGraphPlaying = true;

		private static Key.KeyedList<IUpdatable> _CurrentUpdatables;

		private static int _CurrentUpdatable = -1;

		public static float DefaultFadeDuration
		{
			get
			{
				return _DefaultFadeDuration;
			}
			set
			{
				_DefaultFadeDuration = value;
			}
		}

		public PlayableGraph Graph => _Graph;

		Playable IPlayableWrapper.Playable => _LayerMixer;

		IPlayableWrapper IPlayableWrapper.Parent => null;

		float IPlayableWrapper.Weight => 1f;

		int IPlayableWrapper.ChildCount => Layers.Count;

		public LayerList Layers { get; private set; }

		public StateDictionary States { get; private set; }

		public IAnimancerComponent Component { get; private set; }

		public int CommandCount => Layers[0].CommandCount;

		public DirectorUpdateMode UpdateMode
		{
			get
			{
				return _Graph.GetTimeUpdateMode();
			}
			set
			{
				_Graph.SetTimeUpdateMode(value);
			}
		}

		public float Speed
		{
			get
			{
				return _Speed;
			}
			set
			{
				_LayerMixer.SetSpeed(_Speed = value);
			}
		}

		public bool KeepChildrenConnected
		{
			get
			{
				return _KeepChildrenConnected;
			}
			set
			{
				if (_KeepChildrenConnected == value)
				{
					return;
				}
				_KeepChildrenConnected = value;
				if (value)
				{
					_PostUpdate.IsConnected = true;
					for (int num = Layers.Count - 1; num >= 0; num--)
					{
						Layers.GetLayer(num).ConnectAllChildrenToGraph();
					}
				}
				else
				{
					for (int num2 = Layers.Count - 1; num2 >= 0; num2--)
					{
						Layers.GetLayer(num2).DisconnectWeightlessChildrenFromGraph();
					}
				}
			}
		}

		public bool SkipFirstFade
		{
			get
			{
				return _SkipFirstFade;
			}
			set
			{
				_SkipFirstFade = value;
				if (!value && Layers.Count < 2)
				{
					Layers.Count = 1;
					_LayerMixer.SetInputCount(2);
				}
			}
		}

		public bool IsValid => _Graph.IsValid();

		public List<IDisposable> Disposables => _Disposables ?? (_Disposables = new List<IDisposable>());

		public bool ApplyAnimatorIK
		{
			get
			{
				return _ApplyAnimatorIK;
			}
			set
			{
				_ApplyAnimatorIK = value;
				for (int num = Layers.Count - 1; num >= 0; num--)
				{
					Layers.GetLayer(num).ApplyAnimatorIK = value;
				}
			}
		}

		public bool ApplyFootIK
		{
			get
			{
				return _ApplyFootIK;
			}
			set
			{
				_ApplyFootIK = value;
				for (int num = Layers.Count - 1; num >= 0; num--)
				{
					Layers.GetLayer(num).ApplyFootIK = value;
				}
			}
		}

		object IEnumerator.Current => null;

		public bool IsGraphPlaying
		{
			get
			{
				return _IsGraphPlaying;
			}
			set
			{
				if (value)
				{
					UnpauseGraph();
				}
				else
				{
					PauseGraph();
				}
			}
		}

		public int PreUpdatableCount => _PreUpdatables.Count;

		public int PostUpdatableCount => _PostUpdatables.Count;

		public static AnimancerPlayable Current { get; private set; }

		public static float DeltaTime { get; private set; }

		public ulong FrameID { get; private set; }

		AnimancerNode IPlayableWrapper.GetChild(int index)
		{
			return Layers[index];
		}

		public static AnimancerPlayable Create()
		{
			return Create(PlayableGraph.Create());
		}

		public static AnimancerPlayable Create(PlayableGraph graph)
		{
			return Create(graph, Template);
		}

		protected static T Create<T>(PlayableGraph graph, T template) where T : AnimancerPlayable, new()
		{
			return ScriptPlayable<T>.Create(graph, template, 2).GetBehaviour();
		}

		public override void OnPlayableCreate(Playable playable)
		{
			_RootPlayable = playable;
			_Graph = playable.GetGraph();
			_PostUpdatables = new Key.KeyedList<IUpdatable>();
			_PreUpdatables = new Key.KeyedList<IUpdatable>();
			_PostUpdate = PostUpdate.Create(this);
			Layers = new LayerList(this, out _LayerMixer);
			States = new StateDictionary(this);
			playable.SetInputWeight(0, 1f);
		}

		[Conditional("UNITY_EDITOR")]
		public static void SetNextGraphName(string name)
		{
		}

		public bool TryGetOutput(out PlayableOutput output)
		{
			int outputCount = _Graph.GetOutputCount();
			for (int i = 0; i < outputCount; i++)
			{
				output = _Graph.GetOutput(i);
				if (output.GetSourcePlayable().Equals(_RootPlayable))
				{
					return true;
				}
			}
			output = default(PlayableOutput);
			return false;
		}

		public void CreateOutput(IAnimancerComponent animancer)
		{
			CreateOutput(animancer.Animator, animancer);
		}

		public void CreateOutput(Animator animator, IAnimancerComponent animancer)
		{
			Component = animancer;
			bool isHuman = animator.isHuman;
			KeepChildrenConnected = !isHuman;
			SkipFirstFade = isHuman || animator.runtimeAnimatorController == null;
			AnimationPlayableUtilities.Play(animator, _RootPlayable, _Graph);
			_IsGraphPlaying = true;
		}

		public void InsertOutputPlayable(Playable playable)
		{
			PlayableOutput output = _Graph.GetOutput(0);
			_Graph.Connect(output.GetSourcePlayable(), 0, playable, 0);
			playable.SetInputWeight(0, 1f);
			output.SetSourcePlayable(playable);
		}

		public AnimationScriptPlayable InsertOutputJob<T>(T data) where T : struct, IAnimationJob
		{
			AnimationScriptPlayable animationScriptPlayable = AnimationScriptPlayable.Create(_Graph, data, 1);
			PlayableOutput output = _Graph.GetOutput(0);
			_Graph.Connect(output.GetSourcePlayable(), 0, animationScriptPlayable, 0);
			animationScriptPlayable.SetInputWeight(0, 1f);
			output.SetSourcePlayable(animationScriptPlayable);
			return animationScriptPlayable;
		}

		public void DestroyGraph()
		{
			if (_Graph.IsValid())
			{
				_Graph.Destroy();
			}
		}

		public bool DestroyOutput()
		{
			if (TryGetOutput(out var output))
			{
				_Graph.DestroyOutput(output);
				return true;
			}
			return false;
		}

		public override void OnPlayableDestroy(Playable playable)
		{
			AnimancerPlayable current = Current;
			Current = this;
			DisposeAll();
			GC.SuppressFinalize(this);
			Layers = null;
			States = null;
			Current = current;
		}

		~AnimancerPlayable()
		{
			DisposeAll();
		}

		private void DisposeAll()
		{
			if (_Disposables == null)
			{
				return;
			}
			int num = _Disposables.Count;
			while (true)
			{
				try
				{
					while (--num >= 0)
					{
						_Disposables[num].Dispose();
					}
					_Disposables.Clear();
					_Disposables = null;
					break;
				}
				catch (Exception exception)
				{
					UnityEngine.Debug.LogException(exception, Component as UnityEngine.Object);
				}
			}
		}

		public object GetKey(AnimationClip clip)
		{
			if (Component == null)
			{
				return clip;
			}
			return Component.GetKey(clip);
		}

		public AnimancerState Play(AnimationClip clip)
		{
			return Play(States.GetOrCreate(clip));
		}

		public AnimancerState Play(AnimancerState state)
		{
			return GetLocalLayer(state).Play(state);
		}

		public AnimancerState Play(AnimationClip clip, float fadeDuration, FadeMode mode = FadeMode.FixedSpeed)
		{
			return Play(States.GetOrCreate(clip), fadeDuration, mode);
		}

		public AnimancerState Play(AnimancerState state, float fadeDuration, FadeMode mode = FadeMode.FixedSpeed)
		{
			return GetLocalLayer(state).Play(state, fadeDuration, mode);
		}

		public AnimancerState Play(ITransition transition)
		{
			return Play(transition, transition.FadeDuration, transition.FadeMode);
		}

		public AnimancerState Play(ITransition transition, float fadeDuration, FadeMode mode = FadeMode.FixedSpeed)
		{
			AnimancerState orCreate = States.GetOrCreate(transition);
			orCreate = Play(orCreate, fadeDuration, mode);
			transition.Apply(orCreate);
			return orCreate;
		}

		public AnimancerState TryPlay(object key)
		{
			if (!States.TryGet(key, out var state))
			{
				return null;
			}
			return Play(state);
		}

		public AnimancerState TryPlay(object key, float fadeDuration, FadeMode mode = FadeMode.FixedSpeed)
		{
			if (!States.TryGet(key, out var state))
			{
				return null;
			}
			return Play(state, fadeDuration, mode);
		}

		private AnimancerLayer GetLocalLayer(AnimancerState state)
		{
			if (state.Root == this)
			{
				AnimancerLayer layer = state.Layer;
				if (layer != null)
				{
					return layer;
				}
			}
			return Layers[0];
		}

		public AnimancerState Stop(IHasKey hasKey)
		{
			return Stop(hasKey.Key);
		}

		public AnimancerState Stop(object key)
		{
			if (States.TryGet(key, out var state))
			{
				state.Stop();
			}
			return state;
		}

		public void Stop()
		{
			for (int num = Layers.Count - 1; num >= 0; num--)
			{
				Layers.GetLayer(num).Stop();
			}
		}

		public bool IsPlaying(IHasKey hasKey)
		{
			return IsPlaying(hasKey.Key);
		}

		public bool IsPlaying(object key)
		{
			if (States.TryGet(key, out var state))
			{
				return state.IsPlaying;
			}
			return false;
		}

		public bool IsPlaying()
		{
			if (!_IsGraphPlaying)
			{
				return false;
			}
			for (int num = Layers.Count - 1; num >= 0; num--)
			{
				if (Layers.GetLayer(num).IsAnyStatePlaying())
				{
					return true;
				}
			}
			return false;
		}

		public bool IsPlayingClip(AnimationClip clip)
		{
			if (!_IsGraphPlaying)
			{
				return false;
			}
			for (int num = Layers.Count - 1; num >= 0; num--)
			{
				if (Layers.GetLayer(num).IsPlayingClip(clip))
				{
					return true;
				}
			}
			return false;
		}

		public float GetTotalWeight()
		{
			float num = 0f;
			for (int num2 = Layers.Count - 1; num2 >= 0; num2--)
			{
				num += Layers.GetLayer(num2).GetTotalWeight();
			}
			return num;
		}

		public void GatherAnimationClips(ICollection<AnimationClip> clips)
		{
			Layers.GatherAnimationClips(clips);
		}

		bool IEnumerator.MoveNext()
		{
			for (int num = Layers.Count - 1; num >= 0; num--)
			{
				if (Layers.GetLayer(num).IsPlayingAndNotEnding())
				{
					return true;
				}
			}
			return false;
		}

		void IEnumerator.Reset()
		{
		}

		public void UnpauseGraph()
		{
			if (!_IsGraphPlaying)
			{
				_Graph.Play();
				_IsGraphPlaying = true;
			}
		}

		public void PauseGraph()
		{
			if (_IsGraphPlaying)
			{
				_Graph.Stop();
				_IsGraphPlaying = false;
			}
		}

		public void Evaluate()
		{
			_Graph.Evaluate();
		}

		public void Evaluate(float deltaTime)
		{
			_Graph.Evaluate(deltaTime);
		}

		public string GetDescription()
		{
			StringBuilder stringBuilder = ObjectPool.AcquireStringBuilder();
			AppendDescription(stringBuilder);
			return stringBuilder.ReleaseToString();
		}

		public void AppendDescription(StringBuilder text)
		{
			text.Append("AnimancerPlayable (").Append(Component).Append(") Layer Count: ")
				.Append(Layers.Count);
			AnimancerNode.AppendIKDetails(text, "\n    ", this);
			int count = Layers.Count;
			for (int i = 0; i < count; i++)
			{
				text.Append("\n    ");
				Layers[i].AppendDescription(text, "\n    ");
			}
			text.AppendLine();
			AppendInternalDetails(text, "    ", "        ");
		}

		public void AppendInternalDetails(StringBuilder text, string sectionPrefix, string itemPrefix)
		{
			AppendAll(text, sectionPrefix, itemPrefix, _PreUpdatables, "Pre Updatables");
			text.AppendLine();
			AppendAll(text, sectionPrefix, itemPrefix, _PostUpdatables, "Post Updatables");
			text.AppendLine();
			AppendAll(text, sectionPrefix, itemPrefix, _Disposables, "Disposables");
		}

		private static void AppendAll(StringBuilder text, string sectionPrefix, string itemPrefix, ICollection collection, string name)
		{
			int value = collection?.Count ?? 0;
			text.Append(sectionPrefix).Append(name).Append(": ")
				.Append(value);
			if (collection == null)
			{
				return;
			}
			foreach (object item in collection)
			{
				text.AppendLine().Append(itemPrefix).Append(item);
			}
		}

		public void RequirePreUpdate(IUpdatable updatable)
		{
			_PreUpdatables.AddNew(updatable);
		}

		public void RequirePostUpdate(IUpdatable updatable)
		{
			_PostUpdatables.AddNew(updatable);
		}

		private void CancelUpdate(Key.KeyedList<IUpdatable> updatables, IUpdatable updatable)
		{
			int num = updatables.IndexOf(updatable);
			if (num >= 0)
			{
				updatables.RemoveAtSwap(num);
				if (_CurrentUpdatable < num && updatables == _CurrentUpdatables)
				{
					_CurrentUpdatable--;
				}
			}
		}

		public void CancelPreUpdate(IUpdatable updatable)
		{
			CancelUpdate(_PreUpdatables, updatable);
		}

		public void CancelPostUpdate(IUpdatable updatable)
		{
			CancelUpdate(_PostUpdatables, updatable);
		}

		public IUpdatable GetPreUpdatable(int index)
		{
			return _PreUpdatables[index];
		}

		public IUpdatable GetPostUpdatable(int index)
		{
			return _PostUpdatables[index];
		}

		public override void PrepareFrame(Playable playable, FrameData info)
		{
			UpdateAll(_PreUpdatables, info.deltaTime * info.effectiveParentSpeed);
			if (!_KeepChildrenConnected)
			{
				_PostUpdate.IsConnected = _PostUpdatables.Count != 0;
			}
			FrameID = info.frameId;
		}

		private void UpdateAll(Key.KeyedList<IUpdatable> updatables, float deltaTime)
		{
			AnimancerPlayable current = Current;
			Current = this;
			Key.KeyedList<IUpdatable> currentUpdatables = _CurrentUpdatables;
			_CurrentUpdatables = updatables;
			DeltaTime = deltaTime;
			int currentUpdatable = _CurrentUpdatable;
			_CurrentUpdatable = updatables.Count;
			while (true)
			{
				try
				{
					while (--_CurrentUpdatable >= 0)
					{
						updatables[_CurrentUpdatable].Update();
					}
				}
				catch (Exception exception)
				{
					UnityEngine.Debug.LogException(exception, Component as UnityEngine.Object);
					continue;
				}
				break;
			}
			_CurrentUpdatable = currentUpdatable;
			_CurrentUpdatables = currentUpdatables;
			Current = current;
		}

		public static bool IsRunningPostUpdate(AnimancerPlayable animancer)
		{
			return _CurrentUpdatables == animancer._PostUpdatables;
		}
	}
}
