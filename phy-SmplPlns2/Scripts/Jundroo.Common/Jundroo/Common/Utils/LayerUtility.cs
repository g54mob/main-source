using System;
using System.Collections.Generic;
using Jundroo.Common.Pool;
using Unity.Profiling;
using UnityEngine;

namespace Jundroo.Common.Utils
{
	public static class LayerUtility
	{
		public class TemporaryLayerChanger : IDisposable
		{
			private static class Profile
			{
				public static readonly ProfilerMarker ChangeLayers = new ProfilerMarker("TemporaryLayerChanger.ChangeLayers");

				public static readonly ProfilerMarker RestoreLayers = new ProfilerMarker("TemporaryLayerChanger.RestoreLayers");
			}

			private bool _disposed;

			private List<(GameObject Object, int Layer)> _gameObjectLayers;

			public TemporaryLayerChanger(GameObject rootObject, int layer, bool recursive)
				: this(new GameObject[1] { rootObject }, layer, recursive)
			{
			}

			public TemporaryLayerChanger(IReadOnlyList<GameObject> rootObjects, int layer, bool recursive)
			{
				using (Profile.ChangeLayers.Auto())
				{
					_gameObjectLayers = CollectionPool<List<(GameObject, int)>, (GameObject, int)>.Get();
					Queue<GameObject> value;
					using (QueuePool<GameObject>.Get(out value))
					{
						for (int i = 0; i < rootObjects.Count; i++)
						{
							value.Enqueue(rootObjects[i]);
						}
						ProcessQueue(value, layer, recursive);
					}
				}
			}

			public TemporaryLayerChanger(Component rootObject, int layer, bool recursive)
				: this(new Component[1] { rootObject }, layer, recursive)
			{
			}

			public TemporaryLayerChanger(IReadOnlyList<Component> rootObjects, int layer, bool recursive)
			{
				using (Profile.ChangeLayers.Auto())
				{
					_gameObjectLayers = CollectionPool<List<(GameObject, int)>, (GameObject, int)>.Get();
					Queue<GameObject> value;
					using (QueuePool<GameObject>.Get(out value))
					{
						for (int i = 0; i < rootObjects.Count; i++)
						{
							value.Enqueue(rootObjects[i].gameObject);
						}
						ProcessQueue(value, layer, recursive);
					}
				}
			}

			public void Dispose()
			{
				if (_disposed)
				{
					return;
				}
				_disposed = true;
				using (Profile.RestoreLayers.Auto())
				{
					foreach (var gameObjectLayer in _gameObjectLayers)
					{
						gameObjectLayer.Object.layer = gameObjectLayer.Layer;
					}
					CollectionPool<List<(GameObject, int)>, (GameObject, int)>.Release(_gameObjectLayers);
				}
			}

			private void ProcessQueue(Queue<GameObject> queue, int layer, bool recursive)
			{
				List<(GameObject, int)> gameObjectLayers = _gameObjectLayers;
				if (recursive)
				{
					while (queue.Count > 0)
					{
						GameObject gameObject = queue.Dequeue();
						gameObjectLayers.Add((gameObject, gameObject.layer));
						gameObject.layer = layer;
						Transform transform = gameObject.transform;
						int childCount = transform.childCount;
						for (int i = 0; i < childCount; i++)
						{
							queue.Enqueue(transform.GetChild(i).gameObject);
						}
					}
				}
				else
				{
					while (queue.Count > 0)
					{
						GameObject gameObject2 = queue.Dequeue();
						gameObjectLayers.Add((gameObject2, gameObject2.layer));
						gameObject2.layer = layer;
					}
				}
			}
		}

		public static void SetLayerRecursive(GameObject rootObject, int layer)
		{
			SetLayerRecursive(rootObject.transform, layer);
		}

		public static void SetLayerRecursive(Transform transform, int layer)
		{
			transform.gameObject.layer = layer;
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				SetLayerRecursive(transform.GetChild(i), layer);
			}
		}

		public static void SetLayerRecursive(GameObject rootObject, string layerName, params string[] layersNamesToIgnore)
		{
			int num = LayerMask.NameToLayer(layerName);
			if (layersNamesToIgnore == null)
			{
				SetLayerRecursive(rootObject, num);
				return;
			}
			int num2 = 1 << num;
			for (int i = 0; i < layersNamesToIgnore.Length; i++)
			{
				num2 |= 1 << LayerMask.NameToLayer(layersNamesToIgnore[i]);
			}
			SetLayerRecursiveWithIgnoreMask(rootObject.transform, num, num2);
		}

		public static void SetLayerRecursive(GameObject rootObject, int layer, params int[] layersToIgnore)
		{
			if (layersToIgnore == null)
			{
				SetLayerRecursive(rootObject, layer);
				return;
			}
			int num = 1 << layer;
			for (int i = 0; i < layersToIgnore.Length; i++)
			{
				num |= 1 << layersToIgnore[i];
			}
			SetLayerRecursiveWithIgnoreMask(rootObject.transform, layer, num);
		}

		public static void SetLayerRecursive(GameObject rootObject, int layer, int layerToIgnore1)
		{
			int layerMaskToIgnore = (1 << layer) | (1 << layerToIgnore1);
			SetLayerRecursiveWithIgnoreMask(rootObject.transform, layer, layerMaskToIgnore);
		}

		public static void SetLayerRecursive(GameObject rootObject, int layer, int layerToIgnore1, int layerToIgnore2)
		{
			int layerMaskToIgnore = (1 << layer) | (1 << layerToIgnore1) | (1 << layerToIgnore2);
			SetLayerRecursiveWithIgnoreMask(rootObject.transform, layer, layerMaskToIgnore);
		}

		public static void SetLayerRecursive(GameObject rootObject, int layer, int layerToIgnore1, int layerToIgnore2, int layerToIgnore3)
		{
			int layerMaskToIgnore = (1 << layer) | (1 << layerToIgnore1) | (1 << layerToIgnore2) | (1 << layerToIgnore3);
			SetLayerRecursiveWithIgnoreMask(rootObject.transform, layer, layerMaskToIgnore);
		}

		public static TemporaryLayerChanger TemporarilyChangeLayer(GameObject rootObject, int layer, bool recursive = true)
		{
			return new TemporaryLayerChanger(rootObject, layer, recursive);
		}

		public static TemporaryLayerChanger TemporarilyChangeLayer(IReadOnlyList<GameObject> rootObject, int layer, bool recursive = true)
		{
			return new TemporaryLayerChanger(rootObject, layer, recursive);
		}

		public static TemporaryLayerChanger TemporarilyChangeLayer<T>(T rootObject, int layer, bool recursive = true) where T : Component
		{
			return new TemporaryLayerChanger(rootObject, layer, recursive);
		}

		public static TemporaryLayerChanger TemporarilyChangeLayer<T>(IReadOnlyList<T> rootObjects, int layer, bool recursive = true) where T : Component
		{
			return new TemporaryLayerChanger(rootObjects, layer, recursive);
		}

		private static void SetLayerRecursiveWithIgnoreMask(Transform transform, int layer, int layerMaskToIgnore)
		{
			GameObject gameObject = transform.gameObject;
			if (((1 << gameObject.layer) & layerMaskToIgnore) == 0)
			{
				gameObject.layer = layer;
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				SetLayerRecursiveWithIgnoreMask(transform.GetChild(i), layer, layerMaskToIgnore);
			}
		}
	}
}
