using Client;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Audio;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways.Views
{
	public class TreeView : MonoBehaviour, IView, TreeModel.IObserver, IReleasedFromScopeHandler, IReusable
	{
		public class Builder : IViewBuilder
		{
			public void CreateView(ViewClient client, ISimulation simulation, IModel model, Fix64 timestamp)
			{
				TreeView treeView = client.Scope.Get<TreeView>();
				treeView.Initialize(model as TreeModel);
				client.AddView(treeView);
			}
		}

		[SerializeField]
		private GameObject[] _treeTypes;

		private TreeModel _treeModel;

		public Vector2Int tilePosition;

		[Dependency]
		private IAudioSystem _audioSystem;

		[Dependency]
		private GameCamera _gameCamera;

		[SerializeField]
		private ParticleSystem _explosion;

		public Vector2 Pan => _gameCamera.GetPanFromWorld(base.transform.position);

		public void Initialize(TreeModel model)
		{
			_treeModel = model;
			tilePosition = _treeModel.TileModel.Coordinates;
			base.transform.localPosition = new Vector3((float)tilePosition.x * (float)TilemapModel.TileWidth, (float)tilePosition.y * (float)TilemapModel.TileWidth, 0f);
			for (int i = 0; i < _treeTypes.Length; i++)
			{
				_treeTypes[i].SetActive(_treeModel.PrefabIndex == i);
			}
			_treeModel.Subscribe(this);
		}

		public void OnReleasedFromScope(IScope scope)
		{
			_treeModel?.Unsubscribe(this);
		}

		public void Reset()
		{
			base.transform.localPosition = Vector3.zero;
			_treeModel = null;
			tilePosition = default(Vector2Int);
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_treeModel == null && !_explosion.isPlaying)
			{
				return TickResult.Destroy;
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public void OnBulldozed()
		{
			for (int i = 0; i < _treeTypes.Length; i++)
			{
				_treeTypes[i].SetActive(value: false);
			}
			_explosion.Play();
			_treeModel.Unsubscribe(this);
			_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(_audioSystem.DspTime, AudioEventType.TreeBulldozed, Pan.x));
		}
	}
}
