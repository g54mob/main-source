using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Dorfromantik
{
	public class TileFrequencyAnalyzer : MonoBehaviour
	{
		private sealed class _003CAnalyzeGeneratedTiles_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TileFrequencyAnalyzer _003C_003E4__this;

			public float questTileProbability;

			public float delay;

			public int generatedTileCount;

			private int _003Ci_003E5__2;

			private Tile _003CnewTile_003E5__3;

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
			public _003CAnalyzeGeneratedTiles_003Ed__15(int _003C_003E1__state)
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
				TileFrequencyAnalyzer tileFrequencyAnalyzer = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					tileFrequencyAnalyzer.InitializeDictionaries();
					_003Ci_003E5__2 = 0;
					break;
				case 1:
					_003C_003E1__state = -1;
					goto IL_00a6;
				case 2:
					{
						_003C_003E1__state = -1;
						goto IL_00a6;
					}
					IL_00a6:
					UnityEngine.Object.Destroy(_003CnewTile_003E5__3.gameObject);
					_003CnewTile_003E5__3 = null;
					_003Ci_003E5__2++;
					break;
				}
				if (_003Ci_003E5__2 < generatedTileCount)
				{
					_003CnewTile_003E5__3 = tileFrequencyAnalyzer.tileGenerator.GenerateTile(null, questTileProbability);
					tileFrequencyAnalyzer.CountTile(_003CnewTile_003E5__3);
					if (delay <= 0f)
					{
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						return true;
					}
					_003C_003E2__current = new WaitForSeconds(delay);
					_003C_003E1__state = 2;
					return true;
				}
				return false;
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

		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<ElementGroupSegment, int> _003C_003E9__16_0;

			internal int _003CCountTile_003Eb__16_0(ElementGroupSegment x)
			{
				return x.SegmentType.edges.Count;
			}
		}

		[SerializeField]
		private World world;

		[SerializeField]
		private List<CustomGroupTypeId> groupTypeIds;

		[SerializeField]
		private string outputFileName;

		[SerializeField]
		private SaveFileManager saveFileManager;

		[SerializeField]
		private TileGenerator tileGenerator;

		[SerializeField]
		private int count;

		private Dictionary<string, Dictionary<string, Dictionary<string, int>>> tilePresetFrequencyByPresetId;

		private Dictionary<string, int> countByTypedTilePreset;

		private Dictionary<string, int> countByUntypedTilePreset;

		private Dictionary<GroupType, string> letterByGroupType = new Dictionary<GroupType, string>();

		private Coroutine analysisCoroutine;

		private void InitializeDictionaries()
		{
			tilePresetFrequencyByPresetId = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
			countByTypedTilePreset = new Dictionary<string, int>();
			countByUntypedTilePreset = new Dictionary<string, int>();
			letterByGroupType = new Dictionary<GroupType, string>();
			foreach (CustomGroupTypeId groupTypeId in groupTypeIds)
			{
				letterByGroupType.Add(groupTypeId.groupType, groupTypeId.id);
			}
			count = 0;
		}

		private void AnalyzeMap()
		{
			InitializeDictionaries();
			foreach (Tile allPlacedTile in world.GetAllPlacedTiles())
			{
				CountTile(allPlacedTile);
			}
			Debug.Log($"Analyzed Map {tilePresetFrequencyByPresetId.Count}");
		}

		private void StartAnalyzingGeneratedTiles(int generatedTileCount = 10000, float questTileProbability = 0.1f, float delay = 0.01f)
		{
			if (analysisCoroutine != null)
			{
				StopCoroutine(analysisCoroutine);
			}
			analysisCoroutine = StartCoroutine(AnalyzeGeneratedTiles(generatedTileCount, questTileProbability, delay));
		}

		private void StopAnalyzingGeneratedTiles()
		{
			if (analysisCoroutine != null)
			{
				StopCoroutine(analysisCoroutine);
			}
		}

		private IEnumerator AnalyzeGeneratedTiles(int generatedTileCount, float questTileProbability = 0.1f, float delay = 0f)
		{
			return new _003CAnalyzeGeneratedTiles_003Ed__15(0)
			{
				_003C_003E4__this = this,
				generatedTileCount = generatedTileCount,
				questTileProbability = questTileProbability,
				delay = delay
			};
		}

		private void CountTile(Tile tile)
		{
			string text = "";
			string text2 = "";
			string text3 = "";
			if (tile.AllElementGroupSegments.Count == 0)
			{
				text = "-";
				text2 = "-";
				text3 = "-";
			}
			else
			{
				List<ElementGroupSegment> list = Enumerable.ToList(Enumerable.ThenBy(Enumerable.OrderByDescending(tile.AllElementGroupSegments, (ElementGroupSegment x) => x.SegmentType.edges.Count), (ElementGroupSegment x) => letterByGroupType[x.GroupType]));
				foreach (ElementGroupSegment item in list)
				{
					string text4 = item.SegmentType.name;
					string text5 = text4.Substring(text4.Length - 2, 2);
					text2 = text2 + text5 + letterByGroupType[item.GroupType] + "-";
					text = text + text5 + "-";
				}
				text2 = text2.Remove(text2.Length - 1);
				text = text.Remove(text.Length - 1);
				int num = list[0].RotationIndex + tile.RotationIndex;
				for (int num2 = 0; num2 < 6; num2++)
				{
					List<GroupType> edgeTypes = tile.GetEdgeTypes((num2 + num) % 6, Space.World);
					text3 = ((edgeTypes.Count != 0) ? ((edgeTypes.Count <= 1) ? (text3 + letterByGroupType[edgeTypes[0]]) : (text3 + "X")) : (text3 + "-"));
				}
				if (tile is QuestTile)
				{
					text3 += "Q";
				}
			}
			if (!tilePresetFrequencyByPresetId.ContainsKey(text))
			{
				tilePresetFrequencyByPresetId.Add(text, new Dictionary<string, Dictionary<string, int>>());
			}
			if (!countByUntypedTilePreset.ContainsKey(text))
			{
				countByUntypedTilePreset.Add(text, 0);
			}
			countByUntypedTilePreset[text]++;
			if (!tilePresetFrequencyByPresetId[text].ContainsKey(text2))
			{
				tilePresetFrequencyByPresetId[text].Add(text2, new Dictionary<string, int>());
			}
			if (!countByTypedTilePreset.ContainsKey(text2))
			{
				countByTypedTilePreset.Add(text2, 0);
			}
			countByTypedTilePreset[text2]++;
			if (!tilePresetFrequencyByPresetId[text][text2].ContainsKey(text3))
			{
				tilePresetFrequencyByPresetId[text][text2].Add(text3, 0);
			}
			tilePresetFrequencyByPresetId[text][text2][text3]++;
			count++;
		}

		private void SaveData()
		{
			string text = Application.persistentDataPath + $"{outputFileName}_{DateTime.Now:yyyy-MM-dd}.csv";
			StreamWriter streamWriter = new StreamWriter(text);
			streamWriter.WriteLine(saveFileManager.ActiveSaveGame.fileName ?? "");
			streamWriter.WriteLine("UntypedTilePreset,UntypedTilePresetCount,TypedTilePreset,TypedTilePresetCount,SpecificTile,SpecificTileCount");
			foreach (KeyValuePair<string, Dictionary<string, Dictionary<string, int>>> item in tilePresetFrequencyByPresetId)
			{
				foreach (KeyValuePair<string, Dictionary<string, int>> item2 in item.Value)
				{
					foreach (KeyValuePair<string, int> item3 in item2.Value)
					{
						streamWriter.WriteLine($"{item.Key},{countByUntypedTilePreset[item.Key]}," + $"{item2.Key},{countByTypedTilePreset[item2.Key]}," + $"{item3.Key},{item3.Value}");
					}
				}
			}
			streamWriter.Flush();
			streamWriter.Close();
			Debug.Log("file generated! " + text);
		}

		private string _003CCountTile_003Eb__16_1(ElementGroupSegment x)
		{
			return letterByGroupType[x.GroupType];
		}
	}
}
