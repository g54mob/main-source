using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Craft.Parts;
using ModApi.Exceptions;
using UnityEngine;

namespace ModApi.Craft
{
	public class Assembly
	{
		private List<BodyData> _bodies = new List<BodyData>();

		private List<PartCollision> _partCollisions = new List<PartCollision>();

		private List<PartConnection> _partConnections = new List<PartConnection>();

		private Dictionary<int, PartData> _partDictionary = new Dictionary<int, PartData>();

		private List<PartData> _parts = new List<PartData>();

		public IReadOnlyList<BodyData> Bodies => _bodies;

		public IReadOnlyList<XElement> LoadModifierFailures { get; private set; }

		public IReadOnlyDictionary<string, List<XElement>> MissingParts { get; private set; }

		public IReadOnlyList<PartCollision> PartCollisions => _partCollisions;

		public IReadOnlyList<PartConnection> PartConnections => _partConnections;

		public IReadOnlyList<PartData> Parts => _parts;

		public Assembly(XElement assemblyElement, int craftXmlVersion, PartTypeList partTypes)
		{
			int num = ((int?)assemblyElement.Attribute("xmlVersion")) ?? craftXmlVersion;
			if (num < 15)
			{
				AssemblyXmlVersionUpdater.Upgrade(assemblyElement, num);
			}
			IEnumerable<XElement> enumerable = assemblyElement.Element("Parts").Elements("Part");
			Dictionary<string, List<XElement>> dictionary = new Dictionary<string, List<XElement>>();
			List<XElement> list = (List<XElement>)(LoadModifierFailures = new List<XElement>());
			foreach (XElement item2 in enumerable)
			{
				string text = ((string)item2.Attribute("partType")) ?? string.Empty;
				try
				{
					PartType partType = partTypes.GetPartType(text);
					PartData partData = new PartData(item2, craftXmlVersion, partType);
					_parts.Add(partData);
					AddPartToLookup(partData);
					if (partData.LoadModifierFailures != null)
					{
						list.AddRange(partData.LoadModifierFailures);
					}
				}
				catch (InvalidPartTypeException)
				{
					if (!dictionary.ContainsKey(text))
					{
						dictionary[text] = new List<XElement>();
					}
					dictionary[text].Add(item2);
				}
			}
			MissingParts = dictionary;
			if (MissingParts.Count > 0)
			{
				Debug.LogError("The craft contains the following parts types which could not be loaded: " + string.Join(",", MissingParts.Keys));
			}
			foreach (PartData part in Parts)
			{
				if (part.CommandPodId.HasValue)
				{
					part.CommandPod = GetPartById(part.CommandPodId.Value);
				}
				else
				{
					part.CommandPod = null;
				}
			}
			IEnumerable<XElement> enumerable2 = assemblyElement.Elements("Bodies");
			if (enumerable2 != null)
			{
				foreach (XElement item3 in enumerable2.Elements("Body"))
				{
					BodyData item = new BodyData(item3, this);
					_bodies.Add(item);
				}
			}
			IEnumerable<XElement> enumerable3 = assemblyElement.Elements("Connections");
			if (enumerable3 != null)
			{
				foreach (XElement item4 in enumerable3.Elements("Connection"))
				{
					try
					{
						PartConnection partConnection = new PartConnection(item4, this);
						if (partConnection.Invalid)
						{
							partConnection.DestroyConnection();
						}
						else
						{
							AddPartConnection(partConnection);
						}
					}
					catch (Exception exception)
					{
						Debug.LogError("An error occured creating a part connection.");
						Debug.LogException(exception);
					}
				}
			}
			foreach (XElement item5 in assemblyElement.Elements("Collisions").Elements("Collision"))
			{
				PartCollision partCollision = PartCollision.Create(item5, this);
				if (partCollision != null)
				{
					AddPartCollision(partCollision);
				}
			}
		}

		public Assembly()
		{
		}

		public static Assembly CreateAssemblyFromParts(List<PartData> parts)
		{
			Assembly assembly = new Assembly();
			foreach (PartData part in parts)
			{
				assembly._parts.Add(part);
				assembly.AddPartToLookup(part);
			}
			return assembly;
		}

		public void Absorb(Assembly assembly)
		{
			foreach (PartData part in assembly.Parts)
			{
				AddPart(part);
			}
			foreach (PartConnection partConnection in assembly.PartConnections)
			{
				AddPartConnection(partConnection);
			}
			foreach (PartCollision partCollision in assembly.PartCollisions)
			{
				AddPartCollision(partCollision);
			}
			assembly._partDictionary.Clear();
			assembly._parts.Clear();
			assembly._bodies.Clear();
			assembly._partConnections.Clear();
			assembly._partCollisions.Clear();
		}

		public void AddBody(BodyData body)
		{
			body.Id = GetUniqueBodyId();
			_bodies.Add(body);
		}

		public void AddPart(PartData part)
		{
			part.Id = GetUniquePartId();
			_parts.Add(part);
			AddPartToLookup(part);
		}

		public void AddPartCollision(PartCollision partCollision)
		{
			if (!_partCollisions.Contains(partCollision))
			{
				_partCollisions.Add(partCollision);
			}
			partCollision.SetAssembly(this);
		}

		public void AddPartConnection(PartConnection partConnection)
		{
			if (!_partConnections.Contains(partConnection))
			{
				_partConnections.Add(partConnection);
			}
			partConnection.SetAssembly(this);
		}

		public bool ContainsPart(PartData part)
		{
			PartData value = null;
			if (_partDictionary.TryGetValue(part.Id, out value))
			{
				return value == part;
			}
			return false;
		}

		public XElement GenerateXml(Transform craftTransform, bool subAssembly, bool optimizeXml)
		{
			XElement xElement = new XElement("Parts");
			foreach (PartData part in Parts)
			{
				if (!part.IsDestroyed)
				{
					xElement.Add(part.GenerateXml(craftTransform, optimizeXml));
				}
			}
			XElement xElement2 = new XElement("Connections");
			foreach (PartConnection partConnection in PartConnections)
			{
				if (!partConnection.IsDestroyed)
				{
					xElement2.Add(partConnection.GenerateXml());
				}
				else
				{
					Debug.Log("Part Connection is destroyed. Skipping.");
				}
			}
			XElement xElement3 = new XElement("Collisions");
			foreach (PartCollision partCollision in PartCollisions)
			{
				if ((!subAssembly || !partCollision.AutoGenerated) && _parts.Contains(partCollision.PartA) && _parts.Contains(partCollision.PartB) && !partCollision.PartA.IsDestroyed && !partCollision.PartB.IsDestroyed)
				{
					xElement3.Add(partCollision.GenerateXml());
				}
			}
			XElement xElement4 = new XElement("Bodies");
			foreach (BodyData body in Bodies)
			{
				if (!body.IsDestroyed)
				{
					xElement4.Add(body.GenerateXml(craftTransform));
				}
			}
			return new XElement("Assembly", xElement, xElement2, xElement3, xElement4);
		}

		public BodyData GetBodyById(int bodyId)
		{
			foreach (BodyData body in Bodies)
			{
				if (body.Id == bodyId)
				{
					return body;
				}
			}
			return null;
		}

		public BodyData GetBodyByPartId(int id)
		{
			BodyData result = null;
			foreach (BodyData body in Bodies)
			{
				foreach (PartData part in body.Parts)
				{
					if (part.Id == id)
					{
						result = body;
						break;
					}
				}
			}
			return result;
		}

		public List<T> GetModifiers<T>() where T : PartModifierData
		{
			List<T> list = new List<T>();
			foreach (PartData part in Parts)
			{
				part.GetModifiers(list);
			}
			return list;
		}

		public PartData GetPartById(int partId)
		{
			PartData value = null;
			if (_partDictionary.TryGetValue(partId, out value))
			{
				return value;
			}
			return null;
		}

		public PartData GetPartByName(string partName)
		{
			foreach (PartData part in _parts)
			{
				if (string.Compare(part.Name, partName, ignoreCase: true) == 0)
				{
					return part;
				}
			}
			return null;
		}

		public List<PartCollision> GetPartCollisions(PartData part)
		{
			List<PartCollision> list = new List<PartCollision>();
			foreach (PartCollision partCollision in _partCollisions)
			{
				if (partCollision.PartA == part || partCollision.PartB == part)
				{
					list.Add(partCollision);
				}
			}
			return list;
		}

		public void RemoveAllBodies()
		{
			_bodies.Clear();
		}

		public void RemoveBody(BodyData body)
		{
			_bodies.Remove(body);
		}

		public void RemovePart(PartData part)
		{
			if (_partDictionary.ContainsKey(part.Id))
			{
				_parts.Remove(part);
				_partDictionary.Remove(part.Id);
			}
			else
			{
				Debug.LogErrorFormat("Assembly does not contain part: {0} ({1})", part.Id, part.PartType.Name);
			}
		}

		public bool RemovePartCollision(PartCollision partCollision)
		{
			partCollision.SetAssembly(null);
			return _partCollisions.Remove(partCollision);
		}

		public void RemovePartCollisions(PartData part)
		{
			for (int num = _partCollisions.Count - 1; num >= 0; num--)
			{
				PartCollision partCollision = _partCollisions[num];
				if (partCollision.PartA == part || partCollision.PartB == part)
				{
					partCollision.SetAssembly(null);
					_partCollisions.RemoveAt(num);
				}
			}
		}

		public void RemovePartCollisions(bool autoGeneratedOnly)
		{
			for (int num = _partCollisions.Count - 1; num >= 0; num--)
			{
				if (!autoGeneratedOnly || PartCollisions[num].AutoGenerated)
				{
					_partCollisions[num].SetAssembly(null);
					_partCollisions.RemoveAt(num);
				}
			}
		}

		public void RemovePartConnection(PartConnection partConnection)
		{
			_partConnections.Remove(partConnection);
			partConnection.SetAssembly(null);
		}

		private void AddPartToLookup(PartData part)
		{
			if (!_partDictionary.ContainsKey(part.Id))
			{
				_partDictionary[part.Id] = part;
				return;
			}
			throw new GameException($"Assembly already contains part with ID of {part.Id}");
		}

		private int GetUniqueBodyId()
		{
			int num = 1;
			foreach (BodyData body in Bodies)
			{
				if (body.Id >= num)
				{
					num = body.Id + 1;
				}
			}
			return num;
		}

		private int GetUniquePartId()
		{
			int num = 1;
			foreach (PartData part in Parts)
			{
				if (part.Id >= num)
				{
					num = part.Id + 1;
				}
			}
			return num;
		}
	}
}
