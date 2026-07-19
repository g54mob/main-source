using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace UniHumanoid
{
	public class Bvh
	{
		public struct PathWithProperty
		{
			public string Path;

			public string Property;

			public bool IsLocation;
		}

		private int m_frames;

		public BvhNode Root { get; private set; }

		public TimeSpan FrameTime { get; private set; }

		public ChannelCurve[] Channels { get; private set; }

		public int FrameCount => m_frames;

		public bool TryGetPathWithPropertyFromChannel(ChannelCurve channel, out PathWithProperty pathWithProp)
		{
			int num = Channels.ToList().IndexOf(channel);
			if (num == -1)
			{
				pathWithProp = default(PathWithProperty);
				return false;
			}
			foreach (BvhNode item in Root.Traverse())
			{
				int num2 = 0;
				while (num2 < item.Channels.Length)
				{
					if (num == 0)
					{
						pathWithProp = new PathWithProperty
						{
							Path = GetPath(item),
							Property = item.Channels[num2].ToProperty(),
							IsLocation = item.Channels[num2].IsLocation()
						};
						return true;
					}
					num2++;
					num--;
				}
			}
			throw new BvhException("channel is not found");
		}

		public string GetPath(BvhNode node)
		{
			List<string> list = new List<string> { node.Name };
			BvhNode bvhNode = node;
			while (bvhNode != null)
			{
				bvhNode = GetParent(bvhNode);
				if (bvhNode != null)
				{
					list.Insert(0, bvhNode.Name);
				}
			}
			return string.Join("/", list.ToArray());
		}

		private BvhNode GetParent(BvhNode node)
		{
			foreach (BvhNode item in Root.Traverse())
			{
				if (item.Children.Contains(node))
				{
					return item;
				}
			}
			return null;
		}

		public ChannelCurve GetChannel(BvhNode target, Channel channel)
		{
			int num = 0;
			foreach (BvhNode item in Root.Traverse())
			{
				int num2 = 0;
				while (num2 < item.Channels.Length)
				{
					if (item == target && item.Channels[num2] == channel)
					{
						return Channels[num];
					}
					num2++;
					num++;
				}
			}
			throw new BvhException("channel is not found");
		}

		public override string ToString()
		{
			return $"{Root.Traverse().Count()}nodes, {Channels.Length}channels, {m_frames}frames, {(double)m_frames * FrameTime.TotalSeconds:0.00}seconds";
		}

		public Bvh(BvhNode root, int frames, float seconds)
		{
			Root = root;
			FrameTime = TimeSpan.FromSeconds(seconds);
			m_frames = frames;
			int count = (from x in Root.Traverse()
				where x.Channels != null
				select x.Channels.Length).Sum();
			Channels = (from x in Enumerable.Range(0, count)
				select new ChannelCurve(frames)).ToArray();
		}

		public void ParseFrame(int frame, string line)
		{
			string[] array = (from x in line.Trim().Split()
				where !string.IsNullOrEmpty(x)
				select x).ToArray();
			if (array.Length != Channels.Length)
			{
				throw new BvhException("frame key count is not match channel count");
			}
			for (int num = 0; num < Channels.Length; num++)
			{
				Channels[num].SetKey(frame, float.Parse(array[num], CultureInfo.InvariantCulture));
			}
		}

		public static Bvh Parse(string src)
		{
			using StringReader stringReader = new StringReader(src);
			if (stringReader.ReadLine() != "HIERARCHY")
			{
				throw new BvhException("not start with HIERARCHY");
			}
			BvhNode bvhNode = ParseNode(stringReader);
			if (bvhNode == null)
			{
				return null;
			}
			int num = 0;
			float seconds = 0f;
			if (stringReader.ReadLine() == "MOTION")
			{
				string[] array = stringReader.ReadLine().Split(':');
				if (array[0] != "Frames")
				{
					throw new BvhException("Frames is not found");
				}
				num = int.Parse(array[1]);
				string[] array2 = stringReader.ReadLine().Split(':');
				if (array2[0] != "Frame Time")
				{
					throw new BvhException("Frame Time is not found");
				}
				seconds = float.Parse(array2[1], CultureInfo.InvariantCulture);
			}
			Bvh bvh = new Bvh(bvhNode, num, seconds);
			for (int i = 0; i < num; i++)
			{
				string line = stringReader.ReadLine();
				bvh.ParseFrame(i, line);
			}
			return bvh;
		}

		private static BvhNode ParseNode(StringReader r, int level = 0)
		{
			string text = r.ReadLine().Trim();
			string[] array = text.Split();
			if (array.Length != 2)
			{
				if (array.Length == 1 && array[0] == "}")
				{
					return null;
				}
				throw new BvhException($"split to {array.Length}({text})");
			}
			BvhNode bvhNode = null;
			if (array[0] == "ROOT")
			{
				if (level != 0)
				{
					throw new BvhException("nested ROOT");
				}
				bvhNode = new BvhNode(array[1]);
			}
			else if (array[0] == "JOINT")
			{
				if (level == 0)
				{
					throw new BvhException("should ROOT, but JOINT");
				}
				bvhNode = new BvhNode(array[1]);
			}
			else
			{
				if (!(array[0] == "End"))
				{
					throw new BvhException("unknown type: " + array[0]);
				}
				if (level == 0)
				{
					throw new BvhException("End in level 0");
				}
				bvhNode = new EndSite();
			}
			if (r.ReadLine().Trim() != "{")
			{
				throw new BvhException("'{' is not found");
			}
			bvhNode.Parse(r);
			while (true)
			{
				BvhNode bvhNode2 = ParseNode(r, level + 1);
				if (bvhNode2 == null)
				{
					break;
				}
				if (!(bvhNode2 is EndSite))
				{
					bvhNode.Children.Add(bvhNode2);
				}
			}
			return bvhNode;
		}
	}
}
