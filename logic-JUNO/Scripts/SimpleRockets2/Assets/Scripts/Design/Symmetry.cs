using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design.Tools;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Styles;
using ModApi.Design;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class Symmetry : ISymmetry
	{
		private static readonly Symmetry _Instance = new Symmetry();

		public static ISymmetry Instance => _Instance;

		public static void DeleteSymmetricParts(List<IPartScript> partScripts)
		{
			foreach (PartScript partScript in partScripts)
			{
				ISymmetrySlice symmetrySlice = partScript.SymmetrySlice;
				if (symmetrySlice == null)
				{
					continue;
				}
				foreach (ISymmetrySlice slice in symmetrySlice.SymmetryGroup.Slices)
				{
					if (slice != symmetrySlice)
					{
						PartData part = slice.GetPart(partScript.Data.SymmetryId.Value);
						if (part != null)
						{
							slice.Parts.Remove(part);
							((PartScript)part.PartScript).SymmetrySlice = null;
							part.PartScript.CraftScript.DestroyPart(part, destroyPartGameObject: true);
						}
					}
				}
				symmetrySlice.Parts.Remove(partScript.Data);
				partScript.SymmetrySlice = null;
				partScript.Data.SymmetryId = null;
			}
		}

		public static IEnumerable<IPartScript> DuplicateParts(IPartScript rootPart, bool onlyIncludeGroupedParts = false)
		{
			PartSelection.PartLimb partLimb = PartSelection.FindPartLimb(rootPart, onlyIncludeGroupedParts);
			Dictionary<int, IPartScript> dictionary = new Dictionary<int, IPartScript>();
			foreach (IPartScript part in partLimb.Parts)
			{
				PartData partData = CraftBuilder.DuplicatePart(part.Data, rootPart.CraftScript, clearSymmetryIds: false, clearGroupIds: false);
				dictionary[part.Data.Id] = partData.PartScript;
			}
			Dictionary<PartConnection, bool> dictionary2 = new Dictionary<PartConnection, bool>();
			foreach (IPartScript part2 in partLimb.Parts)
			{
				IPartScript partScript = dictionary[part2.Data.Id];
				foreach (PartConnection partConnection in part2.Data.PartConnections)
				{
					if (dictionary2.ContainsKey(partConnection))
					{
						continue;
					}
					PartData otherPart = partConnection.GetOtherPart(part2.Data);
					if (!dictionary.ContainsKey(otherPart.Id))
					{
						continue;
					}
					IPartScript partScript2 = dictionary[otherPart.Id];
					foreach (PartConnection.Attachment attachment in partConnection.Attachments)
					{
						IPartScript partScript3 = partScript;
						IPartScript partScript4 = partScript2;
						if (partConnection.PartA.PartScript != part2)
						{
							partScript3 = partScript2;
							partScript4 = partScript;
						}
						PartScript.ConnectParts(partScript3.AttachPointScripts[attachment.AttachPointA.Id], partScript4.AttachPointScripts[attachment.AttachPointB.Id], processingSymmetry: true);
					}
					dictionary2[partConnection] = true;
				}
			}
			return dictionary.Values;
		}

		public static IEnumerable<IPartScript> EnumerateSymmetricPartScripts(IPartScript partScript)
		{
			return EnumerateSymmetricPartScripts((PartScript)partScript);
		}

		public static void ExecuteOnSymmetricPartModifiers<TModifier>(TModifier modifier, bool includeSourceModifier, Action<TModifier> action) where TModifier : PartModifierData
		{
			if (includeSourceModifier)
			{
				action(modifier);
			}
			if (!modifier.SymmetryId.HasValue)
			{
				return;
			}
			Guid value = modifier.SymmetryId.Value;
			foreach (IPartScript item in EnumerateSymmetricPartScripts((PartScript)modifier.Part.PartScript))
			{
				TModifier val = null;
				foreach (PartModifierData modifier2 in item.Data.Modifiers)
				{
					if (modifier2.SymmetryId == value)
					{
						val = (TModifier)modifier2;
						break;
					}
				}
				if (val != null)
				{
					action(val);
				}
			}
		}

		public static void ExecuteOnSymmetricPartModifiers<TModifier, TValue>(TModifier modifier, bool includeSourceModifier, TValue value, Action<TModifier, TValue> action) where TModifier : PartModifierData
		{
			if (includeSourceModifier)
			{
				action(modifier, value);
			}
			if (!modifier.SymmetryId.HasValue)
			{
				return;
			}
			Guid value2 = modifier.SymmetryId.Value;
			foreach (IPartScript item in EnumerateSymmetricPartScripts((PartScript)modifier.Part.PartScript))
			{
				TModifier val = null;
				foreach (PartModifierData modifier2 in item.Data.Modifiers)
				{
					if (modifier2.SymmetryId == value2)
					{
						val = (TModifier)modifier2;
						break;
					}
				}
				if (val != null)
				{
					action(val, value);
				}
			}
		}

		public static XElement GenerateSymmetryXml(Assembly assembly)
		{
			XElement xElement = new XElement("Symmetry");
			Dictionary<ISymmetryGroup, bool> dictionary = new Dictionary<ISymmetryGroup, bool>();
			foreach (PartData part in assembly.Parts)
			{
				PartScript partScript = part.PartScript as PartScript;
				if (partScript.SymmetrySlice != null)
				{
					dictionary[partScript.SymmetrySlice.SymmetryGroup] = true;
				}
			}
			foreach (ISymmetryGroup key in dictionary.Keys)
			{
				xElement.Add(((SymmetryGroup)key).GenerateXml());
			}
			return xElement;
		}

		public static List<PartConnection> GetSymmetricPartConnections(IPartScript partScript, PartConnection partConnection, bool includeSourcePart)
		{
			List<PartConnection> list = new List<PartConnection>();
			List<IPartScript> symmetricPartScripts = GetSymmetricPartScripts(partScript);
			if (includeSourcePart)
			{
				symmetricPartScripts.Add(partScript);
			}
			foreach (IPartScript item in symmetricPartScripts)
			{
				list.AddRange(item.Data.PartConnections.Where(delegate(PartConnection x)
				{
					Guid? symmetryId = x.SymmetryId;
					Guid? symmetryId2 = partConnection.SymmetryId;
					if (symmetryId.HasValue != symmetryId2.HasValue)
					{
						return false;
					}
					return !symmetryId.HasValue || symmetryId.GetValueOrDefault() == symmetryId2.GetValueOrDefault();
				}).ToArray());
			}
			return list;
		}

		public static T GetSymmetricPartModifier<T>(T sourceModifier, PartData symmetricPart) where T : PartModifierData
		{
			foreach (PartModifierData modifier in symmetricPart.Modifiers)
			{
				if (modifier.SymmetryId == sourceModifier.SymmetryId)
				{
					return modifier as T;
				}
			}
			return null;
		}

		public static List<IPartScript> GetSymmetricPartScripts(IPartScript partScript)
		{
			List<IPartScript> list = new List<IPartScript>();
			ISymmetrySlice symmetrySlice = ((PartScript)partScript).SymmetrySlice;
			if (symmetrySlice != null)
			{
				foreach (ISymmetrySlice slice in symmetrySlice.SymmetryGroup.Slices)
				{
					if (slice != symmetrySlice)
					{
						IPartScript partScript2 = slice.GetPart(partScript.Data.SymmetryId.Value)?.PartScript;
						if (partScript2 != null)
						{
							list.Add(partScript2);
						}
					}
				}
			}
			return list;
		}

		public static void LoadSymmetryXml(XElement symmetryElement, Assembly assembly)
		{
			try
			{
				if (symmetryElement == null)
				{
					return;
				}
				foreach (XElement item in symmetryElement.Elements("Group"))
				{
					SymmetryGroup.LoadSymmetryGroup(item, assembly);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		public static void RegenerateUniqueGroupIds(IEnumerable<PartData> parts)
		{
			Dictionary<Guid, Guid> dictionary = new Dictionary<Guid, Guid>();
			foreach (PartData part in parts)
			{
				if (part.GroupId.HasValue)
				{
					if (!dictionary.ContainsKey(part.GroupId.Value))
					{
						dictionary[part.GroupId.Value] = Guid.NewGuid();
					}
					part.GroupId = dictionary[part.GroupId.Value];
				}
			}
		}

		public static void RemovePartConnection(IPartScript partScript, PartConnection partConnection)
		{
			foreach (IPartScript item in EnumerateSymmetricPartScripts((PartScript)partScript))
			{
				item.Data.PartConnections.Where(delegate(PartConnection x)
				{
					Guid? symmetryId = x.SymmetryId;
					Guid? symmetryId2 = partConnection.SymmetryId;
					if (symmetryId.HasValue != symmetryId2.HasValue)
					{
						return false;
					}
					return !symmetryId.HasValue || symmetryId.GetValueOrDefault() == symmetryId2.GetValueOrDefault();
				}).FirstOrDefault()?.DestroyConnection();
			}
		}

		public static void RemovePartModifier(IPartScript partScript, PartModifierData partModifier)
		{
			foreach (IPartScript item in EnumerateSymmetricPartScripts((PartScript)partScript))
			{
				item.Data.Modifiers.Where(delegate(PartModifierData x)
				{
					Guid? symmetryId = x.SymmetryId;
					Guid? symmetryId2 = partModifier.SymmetryId;
					if (symmetryId.HasValue != symmetryId2.HasValue)
					{
						return false;
					}
					return !symmetryId.HasValue || symmetryId.GetValueOrDefault() == symmetryId2.GetValueOrDefault();
				}).First().RemoveModifier();
				NotifyPartModifiers(item, partScript, created: false);
			}
		}

		public static void RemoveSymmetryGroup(ISymmetryGroup symmetryGroup)
		{
			foreach (ISymmetrySlice slice in symmetryGroup.Slices)
			{
				foreach (PartData part in slice.Parts)
				{
					PartScript partScript = part.PartScript as PartScript;
					part.SymmetryId = null;
					part.SymmetryMode = SymmetryMode.None;
					partScript.SymmetrySlice = null;
				}
				RegenerateUniqueGroupIds(slice.Parts);
				slice.Parts.Clear();
			}
			symmetryGroup.Slices.Clear();
		}

		public static void RemoveSymmetryGroupsAssociatedWithParts(IEnumerable<PartData> parts)
		{
			foreach (PartData part in parts)
			{
				if (part.PartScript?.SymmetrySlice?.SymmetryGroup != null)
				{
					RemoveSymmetryGroup(part.PartScript.SymmetrySlice.SymmetryGroup);
				}
			}
		}

		public static void SetSymmetryMode(IPartScript partScript, SymmetryMode symmetryMode, IDesignerUi designerUi, int customCount = 0)
		{
			if (!Game.InDesignerScene)
			{
				Debug.LogError("Updating symmetry can only be done in the designer scene.");
			}
			else
			{
				if (partScript == null || partScript.Disconnected)
				{
					return;
				}
				List<PartConnection> list = new List<PartConnection>();
				AttachPoint attachPoint = FindCraftAttachPoint(partScript, list);
				if (partScript.Data.IsRootPart)
				{
					designerUi.ShowMessage("The primary command pod cannot use symmetry.");
				}
				else if (attachPoint != null)
				{
					if (list.Count == 1)
					{
						List<IPartScript> parts = PartData.ToPartScriptList(new PartGraph(partScript.Data, list).Parts);
						partScript.Data.SymmetryMode = symmetryMode;
						UpdateSymmetry(parts, partScript as PartScript, attachPoint, customCount);
						SynchronizePartConnections(partScript);
						partScript.CraftScript.SetStructureChanged();
						if (!Physics.autoSyncTransforms)
						{
							Physics.SyncTransforms();
						}
					}
					else
					{
						designerUi.ShowMessage("The selected part is connected to the craft with more than one attachpoint, make sure it is connected just by one for symmetry to be applied.");
					}
				}
				else
				{
					designerUi.ShowMessage("Part symmetry is not available at this position. It is only available for parts connected to the side of a fuel tank.");
				}
			}
		}

		public static void SynchronizePartConnections(IPartScript partScript)
		{
			ISymmetrySlice symmetrySlice = ((PartScript)partScript).SymmetrySlice;
			if (symmetrySlice == null)
			{
				return;
			}
			foreach (PartConnection partConnection in partScript.Data.PartConnections)
			{
				if (!partConnection.SymmetryId.HasValue)
				{
					partConnection.SymmetryId = Guid.NewGuid();
				}
			}
			foreach (ISymmetrySlice slice in symmetrySlice.SymmetryGroup.Slices)
			{
				if (slice == symmetrySlice)
				{
					continue;
				}
				PartScript partScript2 = slice.GetPart(partScript.Data.SymmetryId.Value)?.PartScript as PartScript;
				if (!(partScript2 != null))
				{
					continue;
				}
				foreach (PartConnection pc in partScript.Data.PartConnections)
				{
					if (partScript2.Data.PartConnections.Any(delegate(PartConnection x)
					{
						Guid? symmetryId = x.SymmetryId;
						Guid? symmetryId2 = pc.SymmetryId;
						if (symmetryId.HasValue != symmetryId2.HasValue)
						{
							return false;
						}
						return !symmetryId.HasValue || symmetryId.GetValueOrDefault() == symmetryId2.GetValueOrDefault();
					}))
					{
						continue;
					}
					PartData otherPart = pc.GetOtherPart(partScript.Data);
					IPartScript partScript3 = null;
					if (otherPart.SymmetryId.HasValue)
					{
						partScript3 = slice.GetPart(otherPart.SymmetryId.Value)?.PartScript;
					}
					else if (symmetrySlice.SymmetryGroup.RootPart == otherPart.PartScript)
					{
						partScript3 = otherPart.PartScript;
					}
					if (partScript3 == null)
					{
						continue;
					}
					foreach (PartConnection.Attachment attachment in pc.Attachments)
					{
						IPartScript partScript4 = partScript2;
						IPartScript partScript5 = partScript3;
						if (pc.PartA.PartScript != partScript)
						{
							partScript4 = partScript3;
							partScript5 = partScript2;
						}
						PartScript.ConnectParts(partScript4.AttachPointScripts[attachment.AttachPointA.Id], partScript5.AttachPointScripts[attachment.AttachPointB.Id], processingSymmetry: true).SymmetryId = pc.SymmetryId;
					}
				}
			}
		}

		public static void SynchronizePartModifiers(IPartScript partScript)
		{
			SynchronizePartModifiers(partScript, GetSymmetricPartScripts(partScript));
		}

		public static void SynchronizeParts(IPartScript partScript, bool synchronizeModifiers = false)
		{
			List<IPartScript> symmetricPartScripts = GetSymmetricPartScripts(partScript);
			if (symmetricPartScripts.Count == 0)
			{
				return;
			}
			PartData data = partScript.Data;
			foreach (IPartScript item in symmetricPartScripts)
			{
				PartData data2 = item.Data;
				data2.ActivationGroup = data.ActivationGroup;
				data2.ActivationStage = data.ActivationStage;
				data2.GroupId = data.GroupId;
			}
			SynchronizePartStyles(partScript, symmetricPartScripts);
			if (synchronizeModifiers)
			{
				SynchronizePartModifiers(partScript, symmetricPartScripts);
			}
		}

		public static void SynchronizePartStyles(IPartScript partScript, List<IPartScript> symmetricParts)
		{
			if (symmetricParts == null)
			{
				symmetricParts = GetSymmetricPartScripts(partScript);
			}
			if (symmetricParts.Count == 0)
			{
				return;
			}
			IReadOnlyList<PartStyleData> styles = partScript.Data.Styles;
			foreach (IPartScript symmetricPart in symmetricParts)
			{
				IReadOnlyList<PartStyleData> styles2 = symmetricPart.Data.Styles;
				int count = styles.Count;
				if (count != styles2.Count)
				{
					Debug.LogError($"Cannot synchronize part styles. Source style count ({count}) does not match " + $"target style count ({styles2.Count}) for part type '{partScript.Data.PartType.Id}'.");
					break;
				}
				bool flag = false;
				for (int i = 0; i < count; i++)
				{
					PartStyleData partStyleData = styles[i];
					PartStyleData partStyleData2 = styles2[i];
					IPartStyle partStyle = null;
					if (partStyleData2.Style != partStyleData.Style)
					{
						partStyle = partStyleData2.Style;
						partStyleData2.Style = partStyleData.Style;
					}
					IPartTextureStyle partTextureStyle = null;
					if (partStyleData2.TextureStyle != partStyleData.TextureStyle)
					{
						partTextureStyle = partStyleData2.TextureStyle;
						partStyleData2.TextureStyle = partStyleData.TextureStyle;
					}
					bool flag2 = partStyle != null || partTextureStyle != null;
					if (!flag2)
					{
						flag2 = !Mathf.Approximately(partStyleData2.TextureOffset.x, partStyleData.TextureOffset.x) || !Mathf.Approximately(partStyleData2.TextureOffset.y, partStyleData.TextureOffset.y) || !Mathf.Approximately(partStyleData2.TextureTiling.x, partStyleData.TextureTiling.x) || !Mathf.Approximately(partStyleData2.TextureTiling.y, partStyleData.TextureTiling.y);
					}
					flag = flag || flag2;
					partStyleData2.TextureOffset = partStyleData.TextureOffset;
					partStyleData2.TextureTiling = partStyleData.TextureTiling;
					if (partStyle != null)
					{
						foreach (PartModifierData modifier in symmetricPart.Data.Modifiers)
						{
							((IDesignerPartModifierData)modifier).DesignerPartProperties?.OnPartStyleChanged(partStyle, partStyleData2.Style);
						}
					}
					if (partTextureStyle == null)
					{
						continue;
					}
					foreach (PartModifierData modifier2 in symmetricPart.Data.Modifiers)
					{
						((IDesignerPartModifierData)modifier2).DesignerPartProperties?.OnPartTextureStyleChanged(partTextureStyle, partStyleData2.TextureStyle);
					}
				}
				if (flag)
				{
					symmetricPart.PartMaterialScript.UpdateTextureData();
				}
			}
		}

		public static void UpdatePartPositions(List<IPartScript> parts)
		{
			Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
			foreach (IPartScript part in parts)
			{
				foreach (IPartScript symmetricPartScript in GetSymmetricPartScripts(part))
				{
					if (!dictionary.ContainsKey(symmetricPartScript.Data.Id))
					{
						dictionary[symmetricPartScript.Data.Id] = true;
						part.SymmetrySlice.UpdatePartTransform(part, symmetricPartScript);
					}
				}
			}
		}

		public static void UpdateSymmetry(List<IPartScript> parts, IPartScript partScript, AttachPoint craftAttachPoint, int customCount = 0)
		{
			SymmetryMode symmetryMode = partScript.Data.SymmetryMode;
			PartScript partScript2 = craftAttachPoint.AttachPointScript.PartScript as PartScript;
			if (partScript.SymmetrySlice == null && partScript2.SymmetrySlice != null)
			{
				AddPartsToSymmetrySlice(partScript2.SymmetrySlice, parts);
			}
			else if (partScript.SymmetrySlice != null && partScript2.SymmetrySlice != null)
			{
				if (partScript.SymmetrySlice != partScript2.SymmetrySlice)
				{
					if (partScript.SymmetrySlice.SliceRootPart == partScript.Data)
					{
						ISymmetryGroup symmetryGroup = partScript.SymmetrySlice.SymmetryGroup;
						DeleteSymmetricParts(parts);
						DeleteSymmetryGroup(symmetryGroup);
					}
					else
					{
						DeleteSymmetricParts(parts);
					}
					AddPartsToSymmetrySlice(partScript2.SymmetrySlice, parts);
				}
			}
			else if (partScript.SymmetrySlice != null && partScript2.SymmetrySlice == null)
			{
				if (partScript.SymmetrySlice.SliceRootPart == partScript.Data)
				{
					ISymmetryGroup symmetryGroup2 = partScript.SymmetrySlice.SymmetryGroup;
					if (symmetryGroup2.AttachPoint != craftAttachPoint || symmetryMode != symmetryGroup2.SymmetryMode || symmetryMode == SymmetryMode.Custom)
					{
						DeleteSymmetricParts(parts);
						DeleteSymmetryGroup(symmetryGroup2);
						if (craftAttachPoint.AllowSymmetry && !craftAttachPoint.AttachPointScript.PartScript.Disconnected && symmetryMode != SymmetryMode.None && (customCount > 0 || symmetryMode != SymmetryMode.Custom))
						{
							CreateSymmetryGroup(parts, partScript, craftAttachPoint, customCount);
						}
					}
				}
				else
				{
					DeleteSymmetricParts(parts);
					if (craftAttachPoint.AllowSymmetry && !craftAttachPoint.AttachPointScript.PartScript.Disconnected && symmetryMode != SymmetryMode.None && (customCount > 0 || symmetryMode != SymmetryMode.Custom))
					{
						CreateSymmetryGroup(parts, partScript, craftAttachPoint, customCount);
					}
				}
			}
			else if (partScript.SymmetrySlice == null && partScript2.SymmetrySlice == null && craftAttachPoint.AllowSymmetry && !craftAttachPoint.AttachPointScript.PartScript.Disconnected && symmetryMode != SymmetryMode.None && (customCount > 0 || symmetryMode != SymmetryMode.Custom))
			{
				CreateSymmetryGroup(parts, partScript, craftAttachPoint, customCount);
			}
			UpdatePartSymmetry(partScript.SymmetrySlice, parts, partScript.CraftScript);
		}

		void ISymmetry.DeleteSymmetricParts(List<IPartScript> partScripts)
		{
			DeleteSymmetricParts(partScripts);
		}

		IEnumerable<IPartScript> ISymmetry.DuplicateParts(IPartScript rootPart)
		{
			return DuplicateParts(rootPart);
		}

		IEnumerable<IPartScript> ISymmetry.EnumerateSymmetricPartScripts(IPartScript partScript)
		{
			return EnumerateSymmetricPartScripts(partScript);
		}

		void ISymmetry.ExecuteOnSymmetricPartModifiers<TModifier>(TModifier modifier, bool includeSourceModifier, Action<TModifier> action)
		{
			ExecuteOnSymmetricPartModifiers(modifier, includeSourceModifier, action);
		}

		void ISymmetry.ExecuteOnSymmetricPartModifiers<TModifier, TValue>(TModifier modifier, bool includeSourceModifier, TValue value, Action<TModifier, TValue> action)
		{
			ExecuteOnSymmetricPartModifiers(modifier, includeSourceModifier, value, action);
		}

		XElement ISymmetry.GenerateSymmetryXml(Assembly assembly)
		{
			return GenerateSymmetryXml(assembly);
		}

		T ISymmetry.GetSymmetricPartModifier<T>(T sourceModifier, PartData symmetricPart)
		{
			return GetSymmetricPartModifier(sourceModifier, symmetricPart);
		}

		List<IPartScript> ISymmetry.GetSymmetricPartScripts(IPartScript partScript)
		{
			return GetSymmetricPartScripts(partScript);
		}

		void ISymmetry.LoadSymmetryXml(XElement symmetryElement, Assembly assembly)
		{
			LoadSymmetryXml(symmetryElement, assembly);
		}

		void ISymmetry.RemovePartConnection(IPartScript partScript, PartConnection partConnection)
		{
			RemovePartConnection(partScript, partConnection);
		}

		void ISymmetry.RemovePartModifier(IPartScript partScript, PartModifierData partModifier)
		{
			RemovePartModifier(partScript, partModifier);
		}

		void ISymmetry.RemoveSymmetryGroup(ISymmetryGroup symmetryGroup)
		{
			RemoveSymmetryGroup(symmetryGroup);
		}

		void ISymmetry.SetSymmetryMode(IPartScript partScript, SymmetryMode symmetryMode, IDesignerUi designerUi)
		{
			SetSymmetryMode(partScript, symmetryMode, designerUi);
		}

		void ISymmetry.SynchronizePartConnections(IPartScript partScript)
		{
			SynchronizePartConnections(partScript);
		}

		void ISymmetry.SynchronizePartModifiers(IPartScript partScript)
		{
			SynchronizePartModifiers(partScript);
		}

		void ISymmetry.SynchronizeParts(IPartScript partScript, bool synchronizeModifiers)
		{
			SynchronizeParts(partScript, synchronizeModifiers);
		}

		void ISymmetry.SynchronizePartStyles(IPartScript partScript, List<IPartScript> symmetricParts)
		{
			SynchronizePartStyles(partScript, symmetricParts);
		}

		void ISymmetry.UpdatePartPositions(List<IPartScript> parts)
		{
			UpdatePartPositions(parts);
		}

		void ISymmetry.UpdateSymmetry(List<IPartScript> parts, IPartScript partScript, AttachPoint craftAttachPoint)
		{
			UpdateSymmetry(parts, partScript, craftAttachPoint);
		}

		private static void AddPartsToSymmetrySlice(ISymmetrySlice slice, List<IPartScript> parts)
		{
			foreach (IPartScript part in parts)
			{
				PartScript partScript = part as PartScript;
				partScript.Data.SymmetryId = Guid.NewGuid();
				partScript.SymmetrySlice = slice;
				slice.Parts.Add(partScript.Data);
				if (part.Data != slice.SliceRootPart)
				{
					part.Data.SymmetryMode = SymmetryMode.None;
				}
				foreach (PartModifierData modifier in part.Data.Modifiers)
				{
					modifier.SymmetryId = Guid.NewGuid();
				}
			}
		}

		private static void CreateSymmetryGroup(List<IPartScript> parts, IPartScript sliceRootPart, AttachPoint targetAttachPoint, int customCount = 0)
		{
			ISymmetrySlice symmetrySlice = new SymmetryGroup(sliceRootPart.Data.SymmetryMode, targetAttachPoint, customCount).Slices[0];
			symmetrySlice.SliceRootPart = sliceRootPart.Data;
			AddPartsToSymmetrySlice(symmetrySlice, parts);
		}

		private static void DeleteSymmetryGroup(ISymmetryGroup group)
		{
			foreach (ISymmetrySlice slice in group.Slices)
			{
				if (slice.Parts.Count > 0)
				{
					throw new Exception("Cannot delete symmetry group that still has parts.");
				}
			}
			group.Slices.Clear();
		}

		private static IEnumerable<IPartScript> EnumerateSymmetricPartScripts(PartScript partScript)
		{
			if (!(partScript != null) || partScript.SymmetrySlice == null)
			{
				yield break;
			}
			foreach (ISymmetrySlice slice in partScript.SymmetrySlice.SymmetryGroup.Slices)
			{
				if (slice != partScript.SymmetrySlice)
				{
					PartData part = slice.GetPart(partScript.Data.SymmetryId.Value);
					if (part != null)
					{
						yield return part.PartScript;
					}
				}
			}
		}

		private static AttachPoint FindCraftAttachPoint(IPartScript partScript, List<PartConnection> craftConnections)
		{
			AttachPoint result = null;
			if (!partScript.Data.IsRootPart)
			{
				foreach (PartConnection partConnection in partScript.Data.PartConnections)
				{
					PartData otherPart = partConnection.GetOtherPart(partScript.Data);
					if (!new PartGraph(otherPart, partScript.Data).HasRoot)
					{
						continue;
					}
					craftConnections.Add(partConnection);
					foreach (PartConnection.Attachment attachment in partConnection.Attachments)
					{
						if (attachment.AttachPointA.AttachPointScript.PartScript.Data == otherPart && attachment.AttachPointA.AllowSymmetry)
						{
							result = attachment.AttachPointA;
						}
						else if (attachment.AttachPointB.AttachPointScript.PartScript.Data == otherPart && attachment.AttachPointB.AllowSymmetry)
						{
							result = attachment.AttachPointB;
						}
					}
				}
			}
			return result;
		}

		private static int GetAttachPointId(AttachPoint attachPoint)
		{
			if (attachPoint.AttachPointScript.PartScript.Data.Mirrored && attachPoint.MirrorId != 0)
			{
				return attachPoint.MirrorId;
			}
			return attachPoint.Id;
		}

		private static void NotifyPartModifiers(IPartScript partScript, IPartScript sourcePartScript, bool created)
		{
			SymmetryMode symmetryMode = partScript.SymmetrySlice.SymmetryGroup.SymmetryMode;
			foreach (PartModifierScript modifier in partScript.Modifiers)
			{
				modifier.OnSymmetry(symmetryMode, sourcePartScript, created);
			}
		}

		private static void SynchronizePartModifiers(IPartScript partScript, List<IPartScript> symmetricParts)
		{
			if (symmetricParts.Count == 0)
			{
				return;
			}
			foreach (IPartScript symmetricPart in symmetricParts)
			{
				List<PartModifierData> modifiers = symmetricPart.Data.Modifiers;
				for (int num = modifiers.Count - 1; num >= 0; num--)
				{
					if (!modifiers[num].SymmetryId.HasValue)
					{
						modifiers[num].RemoveModifier();
					}
				}
			}
			foreach (PartModifierData modifier in partScript.Data.Modifiers)
			{
				if (!modifier.SymmetryId.HasValue)
				{
					modifier.SymmetryId = Guid.NewGuid();
				}
				XElement xElement = modifier.GenerateStateXml(optimizeXml: false);
				foreach (IPartScript symmetricPart2 in symmetricParts)
				{
					PartModifierData partModifierData = symmetricPart2.Data.Modifiers.Where(delegate(PartModifierData x)
					{
						Guid? symmetryId = x.SymmetryId;
						Guid value = modifier.SymmetryId.Value;
						if (!symmetryId.HasValue)
						{
							return false;
						}
						return !symmetryId.HasValue || symmetryId.GetValueOrDefault() == value;
					}).FirstOrDefault();
					if (partModifierData == null)
					{
						partModifierData = PartModifierData.CreateFromXml(modifier.DefaultXml, xElement, symmetricPart2.Data, 15, restoreAllState: true);
						partModifierData.CreateScript();
					}
					else
					{
						partModifierData.CopyFrom(modifier, xElement);
					}
				}
			}
			foreach (IPartScript symmetricPart3 in symmetricParts)
			{
				NotifyPartModifiers(symmetricPart3, partScript, created: false);
			}
		}

		private static void UpdateCommandPod(PartData clonePart, PartData sourcePart)
		{
			if ((object)sourcePart == null || sourcePart.CommandPod?.IsRootPart != false)
			{
				return;
			}
			Guid? guid = sourcePart.CommandPod?.SymmetryId;
			if (guid.HasValue)
			{
				PartData partData = clonePart.PartScript.SymmetrySlice.GetPart(guid.Value)?.CommandPod;
				if (partData != null)
				{
					clonePart.CommandPod = partData;
				}
			}
		}

		private static void UpdatePartSymmetry(ISymmetrySlice sourceSlice, List<IPartScript> parts, ICraftScript craftScript)
		{
			int num = 0;
			if (sourceSlice != null)
			{
				foreach (ISymmetrySlice slice in sourceSlice.SymmetryGroup.Slices)
				{
					if (slice == sourceSlice)
					{
						continue;
					}
					foreach (IPartScript part in parts)
					{
						PartData data = part.Data;
						PartData partData = slice.GetPart(data.SymmetryId.Value);
						if (partData == null)
						{
							num++;
							bool value = false;
							if (slice.SymmetryGroup.SymmetryMode == SymmetryMode.Mirror)
							{
								value = !data.Mirrored;
							}
							partData = CraftBuilder.DuplicatePart(data, craftScript, clearSymmetryIds: false, clearGroupIds: false, value);
							partData.SymmetryId = data.SymmetryId;
							PartScript obj = partData.PartScript as PartScript;
							obj.SymmetrySlice = slice;
							slice.Parts.Add(partData);
							UpdateCommandPod(partData, data);
							NotifyPartModifiers(obj, part, created: true);
							if (sourceSlice.SliceRootPart == data)
							{
								slice.SliceRootPart = partData;
								partData.SymmetryMode = slice.SymmetryGroup.SymmetryMode;
							}
						}
						else
						{
							partData.PartScript.Transform.gameObject.SetActive(value: true);
						}
						partData.GroupId = data.GroupId;
						slice.UpdatePartTransform(data.PartScript as PartScript, partData.PartScript as PartScript);
					}
				}
			}
			if (num <= 0)
			{
				return;
			}
			foreach (IPartScript part2 in parts)
			{
				SynchronizePartConnections(part2);
			}
		}
	}
}
