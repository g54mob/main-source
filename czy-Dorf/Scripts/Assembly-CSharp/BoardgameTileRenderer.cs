using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEngine;

public class BoardgameTileRenderer : MonoBehaviour
{
	private sealed class _003CRenderAllQuestTiles_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BoardgameTileRenderer _003C_003E4__this;

		private int _003Cid_003E5__2;

		private Dictionary<QuestTileId, QuestTile>.ValueCollection.Enumerator _003C_003E7__wrap2;

		private QuestTile _003CquestTilePrefab_003E5__4;

		private int _003Ci_003E5__5;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CRenderAllQuestTiles_003Ed__25(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || (uint)(num - 1) <= 1u)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				BoardgameTileRenderer boardgameTileRenderer = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003Cid_003E5__2 = 0;
					_003C_003E7__wrap2 = boardgameTileRenderer.questSystemConfiguration.QuestTileById.Values.GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_019f;
				case 1:
					_003C_003E1__state = -3;
					boardgameTileRenderer.RenderTile(_003Cid_003E5__2, "QuestTile_", ((boardgameTileRenderer.randomSeedVariants > 1) ? $"-{_003Ci_003E5__5}" : "") ?? "");
					_003C_003E2__current = null;
					_003C_003E1__state = 2;
					return true;
				case 2:
					{
						_003C_003E1__state = -3;
						_003Ci_003E5__5++;
						goto IL_0175;
					}
					IL_019f:
					if (_003C_003E7__wrap2.MoveNext())
					{
						_003CquestTilePrefab_003E5__4 = _003C_003E7__wrap2.Current;
						_003Ci_003E5__5 = 0;
						goto IL_0175;
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap2 = default(Dictionary<QuestTileId, QuestTile>.ValueCollection.Enumerator);
					return false;
					IL_0175:
					if (_003Ci_003E5__5 < boardgameTileRenderer.randomSeedVariants)
					{
						if (boardgameTileRenderer.tile != null)
						{
							UnityEngine.Object.Destroy(boardgameTileRenderer.tile.gameObject);
						}
						QuestTile questTile = (QuestTile)(boardgameTileRenderer.tile = boardgameTileRenderer.questTileGenerator.CreateQuestTile(_003CquestTilePrefab_003E5__4));
						boardgameTileRenderer.tile.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
						BiomeManager.ApplyBiomeToTile(questTile, boardgameTileRenderer.biome);
						questTile.ChangeTileState(TileState.placed);
						questTile.QuestWatcher.HideQuest();
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						return true;
					}
					_003Cid_003E5__2++;
					_003CquestTilePrefab_003E5__4 = null;
					goto IL_019f;
				}
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			((IDisposable)_003C_003E7__wrap2/*cast due to .constrained prefix*/).Dispose();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class _003CRenderAllPossibleTiles_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BoardgameTileRenderer _003C_003E4__this;

		private int _003Cid_003E5__2;

		private int _003CtilePresetIndex_003E5__3;

		private TilePresetConfiguration _003CtilePreset_003E5__4;

		private Dictionary<int, int> _003CgroupTypeIndexBySegmentIndex_003E5__5;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CRenderAllPossibleTiles_003Ed__26(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			BoardgameTileRenderer boardgameTileRenderer = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Cid_003E5__2 = 0;
				_003CtilePresetIndex_003E5__3 = 0;
				goto IL_0633;
			case 1:
				_003C_003E1__state = -1;
				boardgameTileRenderer.RenderTile(_003Cid_003E5__2);
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			case 2:
				{
					_003C_003E1__state = -1;
					_003Cid_003E5__2++;
					_003CgroupTypeIndexBySegmentIndex_003E5__5[5]++;
					goto IL_0458;
				}
				IL_0633:
				if (_003CtilePresetIndex_003E5__3 < boardgameTileRenderer.tileGenConfig.allTilePresets.Count)
				{
					_003CtilePreset_003E5__4 = boardgameTileRenderer.tileGenConfig.allTilePresets[_003CtilePresetIndex_003E5__3];
					_003CgroupTypeIndexBySegmentIndex_003E5__5 = new Dictionary<int, int>
					{
						{ 0, 0 },
						{ 1, 0 },
						{ 2, 0 },
						{ 3, 0 },
						{ 4, 0 },
						{ 5, 0 }
					};
					new Dictionary<int, int>
					{
						{ 0, 0 },
						{ 1, 0 },
						{ 2, 0 },
						{ 3, 0 },
						{ 4, 0 },
						{ 5, 0 }
					};
					_003CgroupTypeIndexBySegmentIndex_003E5__5[0] = 0;
					goto IL_05cf;
				}
				return false;
				IL_0458:
				if (_003CgroupTypeIndexBySegmentIndex_003E5__5[5] < ((_003CtilePreset_003E5__4.segmentProbabilities.Count <= 5) ? 1 : boardgameTileRenderer.groupTypeByCsvValue.Count))
				{
					List<SegmentData002> list = new List<SegmentData002>();
					List<int> list2 = new List<int>();
					for (int i = 0; i < _003CtilePreset_003E5__4.segmentProbabilities.Count; i++)
					{
						SegmentType segmentType = _003CtilePreset_003E5__4.segmentProbabilities[i].segmentType;
						int num2 = -1;
						List<int> list3 = ElementGroupSegmentAdaptor.RotationsToFitOnTile(segmentType.edges, list2);
						if (list3.Count == 0)
						{
							Debug.Log($"no valid rotation for segment {i} {segmentType} on tile preset {_003CtilePreset_003E5__4}");
							continue;
						}
						num2 = list3[0];
						SegmentData002 item = new SegmentData002
						{
							groupType = Enumerable.ToList(boardgameTileRenderer.groupTypeByCsvValue.Values)[_003CgroupTypeIndexBySegmentIndex_003E5__5[i]].id,
							segmentType = segmentType.id,
							rotation = num2
						};
						foreach (int edge in segmentType.edges)
						{
							list2.Add((edge + num2) % 6);
						}
						list.Add(item);
					}
					if (boardgameTileRenderer.tile != null)
					{
						UnityEngine.Object.Destroy(boardgameTileRenderer.tile.gameObject);
					}
					boardgameTileRenderer.tile = UnityEngine.Object.Instantiate(boardgameTileRenderer.tilePrefab, boardgameTileRenderer.transform);
					boardgameTileRenderer.tile.InitializeSeed();
					boardgameTileRenderer.tileFactory.CreateTile(boardgameTileRenderer.tile, list);
					boardgameTileRenderer.tile.Initialize();
					BiomeManager.ApplyBiomeToTile(boardgameTileRenderer.tile, boardgameTileRenderer.biome);
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				_003CgroupTypeIndexBySegmentIndex_003E5__5[4]++;
				goto IL_04a3;
				IL_0539:
				if (_003CgroupTypeIndexBySegmentIndex_003E5__5[2] < ((_003CtilePreset_003E5__4.segmentProbabilities.Count <= 2) ? 1 : boardgameTileRenderer.groupTypeByCsvValue.Count))
				{
					Debug.Log($"{_003CtilePreset_003E5__4.name} - segment 2: {((_003CtilePreset_003E5__4.segmentProbabilities.Count <= 2) ? 1 : boardgameTileRenderer.groupTypeByCsvValue.Count)} " + $"group type possibilities, now rendering group Type {_003CgroupTypeIndexBySegmentIndex_003E5__5[2]}");
					_003CgroupTypeIndexBySegmentIndex_003E5__5[3] = 0;
					goto IL_04ee;
				}
				_003CgroupTypeIndexBySegmentIndex_003E5__5[1]++;
				goto IL_0584;
				IL_05cf:
				if (_003CgroupTypeIndexBySegmentIndex_003E5__5[0] < ((_003CtilePreset_003E5__4.segmentProbabilities.Count <= 0) ? 1 : boardgameTileRenderer.groupTypeByCsvValue.Count))
				{
					Debug.Log($"{_003CtilePreset_003E5__4.name} - segment 0: {((_003CtilePreset_003E5__4.segmentProbabilities.Count <= 0) ? 1 : boardgameTileRenderer.groupTypeByCsvValue.Count)} " + $"group type possibilities, now rendering group Type {_003CgroupTypeIndexBySegmentIndex_003E5__5[0]}");
					_003CgroupTypeIndexBySegmentIndex_003E5__5[1] = 0;
					goto IL_0584;
				}
				_003Cid_003E5__2++;
				_003CtilePreset_003E5__4 = null;
				_003CgroupTypeIndexBySegmentIndex_003E5__5 = null;
				_003CtilePresetIndex_003E5__3++;
				goto IL_0633;
				IL_04ee:
				if (_003CgroupTypeIndexBySegmentIndex_003E5__5[3] < ((_003CtilePreset_003E5__4.segmentProbabilities.Count <= 3) ? 1 : boardgameTileRenderer.groupTypeByCsvValue.Count))
				{
					_003CgroupTypeIndexBySegmentIndex_003E5__5[4] = 0;
					goto IL_04a3;
				}
				_003CgroupTypeIndexBySegmentIndex_003E5__5[2]++;
				goto IL_0539;
				IL_0584:
				if (_003CgroupTypeIndexBySegmentIndex_003E5__5[1] < ((_003CtilePreset_003E5__4.segmentProbabilities.Count <= 1) ? 1 : boardgameTileRenderer.groupTypeByCsvValue.Count))
				{
					Debug.Log($"{_003CtilePreset_003E5__4.name} - segment 1: {((_003CtilePreset_003E5__4.segmentProbabilities.Count <= 1) ? 1 : boardgameTileRenderer.groupTypeByCsvValue.Count)} " + $"group type possibilities, now rendering group Type {_003CgroupTypeIndexBySegmentIndex_003E5__5[1]}");
					_003CgroupTypeIndexBySegmentIndex_003E5__5[2] = 0;
					goto IL_0539;
				}
				_003CgroupTypeIndexBySegmentIndex_003E5__5[0]++;
				goto IL_05cf;
				IL_04a3:
				if (_003CgroupTypeIndexBySegmentIndex_003E5__5[4] < ((_003CtilePreset_003E5__4.segmentProbabilities.Count <= 4) ? 1 : boardgameTileRenderer.groupTypeByCsvValue.Count))
				{
					_003CgroupTypeIndexBySegmentIndex_003E5__5[5] = 0;
					goto IL_0458;
				}
				_003CgroupTypeIndexBySegmentIndex_003E5__5[3]++;
				goto IL_04ee;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class _003CRenderAllDataTiles_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BoardgameTileRenderer _003C_003E4__this;

		private List<TileCsvData>.Enumerator _003C_003E7__wrap1;

		private TileCsvData _003CloadedTileCsvData_003E5__3;

		private int _003Ci_003E5__4;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CRenderAllDataTiles_003Ed__27(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || (uint)(num - 1) <= 1u)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				BoardgameTileRenderer boardgameTileRenderer = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					boardgameTileRenderer.loadedTileData = boardgameTileRenderer.LoadTileData();
					_003C_003E7__wrap1 = boardgameTileRenderer.loadedTileData.GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_0197;
				case 1:
					_003C_003E1__state = -3;
					boardgameTileRenderer.RenderTile(_003CloadedTileCsvData_003E5__3.id, "Tile_", (boardgameTileRenderer.randomSeedVariants > 1) ? $"-{_003Ci_003E5__4}" : "");
					_003C_003E2__current = null;
					_003C_003E1__state = 2;
					return true;
				case 2:
					{
						_003C_003E1__state = -3;
						_003Ci_003E5__4++;
						goto IL_017f;
					}
					IL_017f:
					if (_003Ci_003E5__4 < boardgameTileRenderer.randomSeedVariants)
					{
						if (boardgameTileRenderer.tile != null)
						{
							UnityEngine.Object.Destroy(boardgameTileRenderer.tile.gameObject);
						}
						boardgameTileRenderer.tile = UnityEngine.Object.Instantiate(boardgameTileRenderer.tilePrefab, boardgameTileRenderer.transform);
						boardgameTileRenderer.tile.InitializeSeed();
						boardgameTileRenderer.tileFactory.CreateTile(boardgameTileRenderer.tile, _003CloadedTileCsvData_003E5__3.segmentInfos);
						boardgameTileRenderer.tile.Initialize();
						boardgameTileRenderer.tile.ChangeTileState(TileState.placementPreview);
						BiomeManager.ApplyBiomeToTile(boardgameTileRenderer.tile, boardgameTileRenderer.biome);
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						return true;
					}
					_003CloadedTileCsvData_003E5__3 = null;
					goto IL_0197;
					IL_0197:
					if (_003C_003E7__wrap1.MoveNext())
					{
						_003CloadedTileCsvData_003E5__3 = _003C_003E7__wrap1.Current;
						_003Ci_003E5__4 = 0;
						goto IL_017f;
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap1 = default(List<TileCsvData>.Enumerator);
					return false;
				}
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			((IDisposable)_003C_003E7__wrap1/*cast due to .constrained prefix*/).Dispose();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	private string tileCsvDataPathWithinPersistentDataPath;

	[SerializeField]
	private Biome biome;

	[SerializeField]
	private int randomSeedVariants = 1;

	[SerializeField]
	private Camera renderCamera;

	[SerializeField]
	private RenderTexture renderTextureReference;

	[SerializeField]
	private TileFactory tileFactory;

	[SerializeField]
	private ElementGroupSegmentCreator segmentCreator;

	[SerializeField]
	private Tile tilePrefab;

	[SerializeField]
	private List<CustomGroupTypeId> groupTypeIds;

	[SerializeField]
	private QuestSystemConfiguration questSystemConfiguration;

	[SerializeField]
	private QuestTileGenerator questTileGenerator;

	[SerializeField]
	private TileGenConfiguration tileGenConfig;

	private Tile tile;

	private string rawTileData;

	private List<TileCsvData> loadedTileData;

	private RenderTexture usedRenderTexture;

	private Dictionary<string, GroupType> groupTypeByCsvValue = new Dictionary<string, GroupType>();

	private Coroutine runningCoroutine;

	private string TileCsvDataPath => Application.persistentDataPath + "/" + tileCsvDataPathWithinPersistentDataPath;

	private void Start()
	{
		foreach (CustomGroupTypeId groupTypeId in groupTypeIds)
		{
			groupTypeByCsvValue.Add(groupTypeId.id, groupTypeId.groupType);
		}
		usedRenderTexture = new RenderTexture(renderTextureReference);
	}

	private void StartRenderingAllTiles()
	{
		StartCoroutine(RenderAllDataTiles());
	}

	private void StartRenderingAllQuestTiles()
	{
		questSystemConfiguration.Setup();
		StartCoroutine(RenderAllQuestTiles());
	}

	private void StartRenderingAlPossibleTiles()
	{
		runningCoroutine = StartCoroutine(RenderAllPossibleTiles());
	}

	private void Cancel()
	{
		if (runningCoroutine != null)
		{
			StopCoroutine(runningCoroutine);
		}
		if (tile != null)
		{
			UnityEngine.Object.Destroy(tile.gameObject);
		}
		tile = null;
	}

	private IEnumerator RenderAllQuestTiles()
	{
		return new _003CRenderAllQuestTiles_003Ed__25(0)
		{
			_003C_003E4__this = this
		};
	}

	private IEnumerator RenderAllPossibleTiles()
	{
		return new _003CRenderAllPossibleTiles_003Ed__26(0)
		{
			_003C_003E4__this = this
		};
	}

	private IEnumerator RenderAllDataTiles()
	{
		return new _003CRenderAllDataTiles_003Ed__27(0)
		{
			_003C_003E4__this = this
		};
	}

	private List<TileCsvData> LoadTileData()
	{
		rawTileData = "";
		if (File.Exists(TileCsvDataPath))
		{
			FileStream fileStream = new FileStream(TileCsvDataPath, FileMode.Open, FileAccess.ReadWrite);
			StreamReader streamReader = new StreamReader(fileStream);
			rawTileData = streamReader.ReadToEnd();
			fileStream.Close();
		}
		else
		{
			Debug.LogError("File at " + TileCsvDataPath + " does not exist");
		}
		if (string.IsNullOrWhiteSpace(rawTileData))
		{
			return null;
		}
		string[] array = rawTileData.Split('\n');
		List<TileCsvData> list = new List<TileCsvData>();
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			string[] array3 = array2[i].Split(',');
			if (!int.TryParse(array3[0], out var result))
			{
				continue;
			}
			TileCsvData tileCsvData = new TileCsvData
			{
				id = result
			};
			Dictionary<GroupType, List<int>> dictionary = new Dictionary<GroupType, List<int>>();
			for (int j = 1; j < 7; j++)
			{
				if (!string.IsNullOrWhiteSpace(array3[j]))
				{
					GroupType key = groupTypeByCsvValue[array3[j]];
					if (!dictionary.ContainsKey(key))
					{
						dictionary.Add(key, new List<int>());
					}
					dictionary[key].Add(j - 1);
				}
			}
			foreach (KeyValuePair<GroupType, List<int>> item in dictionary)
			{
				SegmentData002 segmentData = new SegmentData002
				{
					groupType = item.Key.id
				};
				segmentCreator.DetermineSegmentTypeAndRotationFromEdges(item.Value, out segmentData.segmentType, out segmentData.rotation);
				tileCsvData.segmentInfos.Add(segmentData);
			}
			Debug.Log($"tile id {result}: ");
			foreach (SegmentData002 segmentInfo in tileCsvData.segmentInfos)
			{
				Debug.Log($"segment: {segmentInfo.groupType} | {segmentInfo.segmentType} | {segmentInfo.rotation}");
			}
			list.Add(tileCsvData);
		}
		return list;
	}

	private void RenderTile(int id, string prefix = "Tile_", string suffix = "")
	{
		renderCamera.targetTexture = usedRenderTexture;
		renderCamera.Render();
		Texture2D texture2D = new Texture2D(usedRenderTexture.width, usedRenderTexture.height, TextureFormat.RGBA32, mipChain: false);
		RenderTexture.active = usedRenderTexture;
		texture2D.ReadPixels(new Rect(0f, 0f, usedRenderTexture.width, usedRenderTexture.height), 0, 0);
		texture2D.Apply();
		byte[] bytes = ImageConversion.EncodeToPNG(texture2D);
		string path = $"{prefix}{id:00}{suffix}_{usedRenderTexture.width}px_{biome.name}.png";
		string path2 = Path.Combine(Application.persistentDataPath, "Renders", path);
		BinarySaveLoad.CreateDirectories(path2);
		File.WriteAllBytes(path2, bytes);
		renderCamera.targetTexture = null;
	}
}
