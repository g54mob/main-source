using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Motorways.Audio
{
	public class Quality
	{
		public string Name;

		public List<int> Intervals;

		public List<int> BaseStack;

		public List<int> FullStack;

		public Scale BaseScale;

		public List<Scale> Scales = new List<Scale>();

		public bool IsKeyless;

		public string FullName()
		{
			return Note.SCALE[Get.Loadout.MusicData.CurrentKey] + " " + Name;
		}

		public Quality(string name, List<int> intervals, List<int> baseStack = null)
		{
			BaseScale = new Scale(0, name, intervals, baseStack);
			Scales.Add(BaseScale);
			Name = name;
			Intervals = intervals;
			BaseStack = BaseScale.BaseStack;
			FullStack = BaseScale.FullStack;
		}

		public static Quality Clone(Quality q, string newName = "")
		{
			if (q == null)
			{
				return null;
			}
			return new Quality((newName.Length > 0) ? newName : q.Name, q.Intervals, q.BaseStack)
			{
				Scales = q.Scales.ToList(),
				IsKeyless = q.IsKeyless
			};
		}

		public Quality Modal(params string[] modeNames)
		{
			Quality quality = Clone(this);
			quality.IsKeyless = true;
			quality.Scales[0].Name = ((modeNames.Length != 0) ? modeNames[0] : quality.Scales[0].Name);
			for (int i = 1; i < quality.Intervals.Count; i++)
			{
				quality.Scales.Add(quality.Scales[quality.Scales.Count - 1].Rotate(1, (i < modeNames.Length) ? modeNames[i] : (quality.Name + " " + (i + 1))));
			}
			return quality;
		}

		public Quality ModalVerbose(params Scale.Data[] modes)
		{
			Quality quality = Clone(this);
			quality.IsKeyless = true;
			for (int i = 0; i < quality.Intervals.Count; i++)
			{
				if (i > 0)
				{
					quality.Scales.Add(quality.Scales[quality.Scales.Count - 1].Rotate(1, (i < modes.Length) ? modes[i].Name : (quality.Name + " " + (i + 1))));
				}
				else
				{
					quality.Scales[i].Name = ((modes.Length != 0) ? modes[i].Name : quality.Scales[i].Name);
				}
				quality.Scales.Last().Restack(quality.BaseStack.Union(modes[i].Stack).ToList());
			}
			return quality;
		}

		public Quality Transpose(int delta)
		{
			Quality quality = Clone(this);
			quality.Scales.Edit(delegate(Scale x)
			{
				x.IsOriginal = false;
				return x.Transpose(delta);
			});
			return quality;
		}

		public Quality Chromatic(string addendName = "")
		{
			Quality quality = Clone(this);
			quality.Name += ((addendName.Length > 0) ? (" " + addendName) : "");
			foreach (Scale item in quality.Scales.ToList())
			{
				for (int i = 1; i < 12; i++)
				{
					Scale scale = item.Transpose(i);
					quality.Scales.Add(scale);
					scale.IsOriginal = false;
				}
			}
			return quality;
		}

		public Quality Chromodal(params string[] modeNames)
		{
			return Modal(modeNames).Chromatic();
		}

		public Quality Keyless()
		{
			Quality quality = Clone(this);
			for (int num = quality.Scales.Count - 1; num > 0; num--)
			{
				if (!quality.Scales[num].IsOriginal)
				{
					quality.Scales.Remove(quality.Scales[num]);
				}
			}
			quality.Scales.Edit((Scale x) => x.Transpose(-x.Key));
			quality.IsKeyless = true;
			return quality;
		}

		public static Quality GetMode(Quality q, int modeIndex, string newName = "")
		{
			if (modeIndex > q.Scales.Count - 1)
			{
				Dbug.Log.Error("Mode Index {0} requested from Quality {1} is out of range. Quality only has {2} scales.", modeIndex, q.Name, (q.Scales.Count > 0) ? q.Scales.Count : 0);
			}
			return new Quality((newName.Length > 0) ? newName : q.Scales[modeIndex].Name, q.Scales[modeIndex].Intervals, q.Scales[modeIndex].BaseStack).Chromatic();
		}

		public Quality GetMode(int modeIndex, string newName = "")
		{
			return GetMode(this, modeIndex, newName);
		}

		public List<Quality> ToModes()
		{
			return Liszt.Make(Scales.Count, (int i) => new Quality(Scales[i].Name, Scales[i].Intervals, Scales[i].BaseStack).Chromatic());
		}

		public Quality SetName(string name)
		{
			Name = name;
			return this;
		}

		public List<string> CommonToneChord(List<string> currentChord, int commonTones, int newSize, ref Scale scale, ref int iterations)
		{
			if (!Diagnostics.Verify(Scales.Count > 0))
			{
				Dbug.Log.Error("Quality {0} has no scales !", Name);
			}
			List<Scale> list = Scales;
			if (IsKeyless)
			{
				list = Scales.ToList();
				list.Edit((Scale x) => x.Transpose(Get.Loadout.MusicData.CurrentKey));
			}
			List<string> list2 = new List<string>();
			List<int> list3 = Rando.Numbers(list.Count);
			for (int num = 0; num < list.Count; num++)
			{
				iterations++;
				Dbug.Log.Info("Iteration {0}.", iterations);
				if (num > 11)
				{
					Dbug.Log.Info("Traversed 12 of the {0} scales in this quality with no success. exiting early...", list.Count);
					break;
				}
				if (iterations > 100)
				{
					Dbug.Log.Info("Taking too long ... exiting early.");
					break;
				}
				int index = list3[num];
				string text = Note.SCALE[list[index].Key];
				int num2 = list[index].Notes.Count((string x) => currentChord.Contains(x));
				if (num2 < commonTones)
				{
					Dbug.Log.Info("{0} > {1} : only {2} commonTones. continuing...", Name, list[index].FullName(), num2);
					continue;
				}
				list2 = Liszt.Make(newSize, (int x) => "");
				List<string> list4 = new List<string>();
				List<string> newNonCommonTones = new List<string>();
				bool flag = false;
				Dbug.Log.Info("CommonToneChord(), requesting {0} commonTones and {1} non common tones from {2} {3}", commonTones, newSize - commonTones, text, Name);
				int num3 = list[index].Notes.Count;
				int num4 = newSize - commonTones;
				foreach (string note in list[index].Notes)
				{
					bool flag2 = currentChord.Contains(note);
					if (list4.Count < commonTones && flag2)
					{
						list4.Add(note);
						int index2 = currentChord.IndexOf(note);
						list2[index2] = note;
						Dbug.Log.Info("Adding Common Tone {0}.", note);
					}
					else if (newNonCommonTones.Count < num4 && !flag2)
					{
						Dbug.Log.Info("Adding Non-Common Tone {0}.", note);
						newNonCommonTones.Add(note);
					}
					num3--;
					bool num5 = num3 < newSize - (list4.Count + newNonCommonTones.Count);
					flag = list4.Count + newNonCommonTones.Count >= newSize;
					if (num5 || flag)
					{
						Dbug.Log.Info("Size fulfilled, or not enough notes left to succeed. Breaking early ...");
						break;
					}
				}
				if (flag)
				{
					Dbug.Log.Info("Success! {2} {3} has {0} common tones and {1} non-common tones.", list4.Count, newNonCommonTones.Count, text, Name);
					list2.Edit(delegate(string x)
					{
						if (x == "")
						{
							int index3 = Rando.Index(newNonCommonTones);
							string result = newNonCommonTones[index3];
							newNonCommonTones.RemoveAt(index3);
							return result;
						}
						return x;
					});
					scale = list[index];
					break;
				}
				Dbug.Log.Info("{2} {3} only has {0} common tones, and {1} non-common tones. Continuing ...", list4.Count, newNonCommonTones.Count, text, Name);
				list2.Clear();
			}
			return list2;
		}

		public static List<string> IntervalsToNotes(List<int> intervals)
		{
			return Liszt.Make(Mathf.Min(intervals.Count, Note.RANGE.Count), (int i) => Note.RANGE[intervals[i]]);
		}

		public static List<int> NotesToIntervals(List<string> notes)
		{
			return Liszt.Make(notes.Count, (int i) => Note.RANGE.IndexOf(notes[i]));
		}

		public List<string> Notes(string key, int size, out Scale newScale)
		{
			return Notes(Note.SCALE.IndexOf(key), size, out newScale);
		}

		public List<string> Notes(int key, int size, out Scale newScale)
		{
			newScale = (IsKeyless ? Rando.Pick(Scales).Transpose(key) : Scales[key]);
			return newScale.Notes.ToList().Whittle(size);
		}

		public override string ToString()
		{
			return string.Format("Quality: {0}\nIntervals: {1}\nBaseStack: {2}\nFull Stack: {3}\nScales:\n{4}", Name, string.Join(", ", Intervals), (BaseStack != null) ? string.Join(", ", BaseStack) : "null", string.Join(", ", FullStack), string.Join("\n", Scales));
		}
	}
}
