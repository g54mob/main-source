using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Craft.Wings.Runtime;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Craft.Wings.ControlSurfaces
{
	[Serializable]
	public abstract class ControlSurface
	{
		public struct MeshDefinition
		{
			public bool HasCollider;

			public int? Parent;

			public MeshDefinition(bool hasCollider, int? parent = null)
			{
				HasCollider = hasCollider;
				Parent = parent;
			}
		}

		public const string XmlTag = "ControlSurface";

		private string _style;

		public static Dictionary<string, Func<ControlSurface>> Styles { get; private set; }

		public abstract SurfaceLocation Location { get; }

		public int MeshCount => MeshDefinitions.Length;

		public abstract MeshDefinition[] MeshDefinitions { get; }

		public int MeshIndexOffset { get; set; }

		public virtual float2 Range { get; set; }

		public short SectionCount { get; set; }

		public short SectionOffset { get; set; }

		public byte SurfaceId { get; set; }

		static ControlSurface()
		{
			Styles = new Dictionary<string, Func<ControlSurface>>
			{
				{
					"StandardFlap",
					() => new StandardFlap()
				},
				{
					"Spoiler",
					() => new Spoiler()
				},
				{
					"FowlerFlap",
					() => new FowlerFlap()
				},
				{
					"SplitFlap",
					() => new SplitFlap()
				},
				{
					"BrakeFlap",
					() => new BrakeFlap()
				},
				{
					"Slat",
					() => new Slat()
				}
			};
		}

		public static ControlSurface GetStyle(string style)
		{
			if (Styles.TryGetValue(style, out var value))
			{
				ControlSurface controlSurface = value();
				controlSurface._style = style;
				return controlSurface;
			}
			throw new ArgumentException("Style not found: " + style);
		}

		public static ControlSurface TryCreateControlSurface(XElement element)
		{
			try
			{
				ControlSurface style = GetStyle((string)element.Attribute("style"));
				style.Init(element);
				return style;
			}
			catch (Exception arg)
			{
				Debug.LogWarning($"Error while parsing control surface: {arg}");
				return null;
			}
		}

		public static void UpdateClone(ref ControlSurface clone, ControlSurface target)
		{
			if (clone == null || clone._style != target._style)
			{
				clone = GetStyle(target._style);
			}
			target.CopySettingsTo(clone);
		}

		public virtual void AddToClaims(WingSurfaceClaims claims)
		{
		}

		public virtual void AllocateNativeData(int sliceCount)
		{
		}

		public virtual bool ApplyToColliders(NativeList<float3> mainCollider, Span<NativeList<float3>> surfaceColliders, int sliceIndex)
		{
			return false;
		}

		public abstract void ApplyToCrossSections(ControlSurfaceSectionInput input);

		public virtual void CopySettingsTo(ControlSurface dest)
		{
			dest.Range = Range;
		}

		public virtual void FreeNativeData()
		{
		}

		public abstract IControlSurfaceRuntimeData GetRuntimeData(bool wingFlipped);

		public virtual void HandleSectionChange(in WingSectionChange change)
		{
			float2 range = Range;
			range.x = change.RemapSpanPosition(range.x);
			range.y = change.RemapSpanPosition(range.y);
			Range = range;
		}

		public virtual void HandleSliceChange(in WingSliceChange change)
		{
		}

		public virtual void Init(XElement xml)
		{
			Range = xml.GetVector2AttributeOrNull("range") ?? throw new ArgumentException($"Control surface missing range attribute: {xml}");
		}

		public virtual void PostPass(MeshBuilder[] meshes)
		{
		}

		public virtual void PrePass(ReadOnlySpan<WingSlice> inSlices, NativeList<SurfaceRegion.Slice> regions)
		{
		}

		public virtual void ResetShape()
		{
			Range = new float2(0f, 2f);
		}

		public virtual void SaveToXml(XElement xml)
		{
			xml.SetAttributeValue("style", _style);
			xml.SetAttribute("range", Range);
		}

		public virtual bool TryChangeRange(float newPos, bool isRootSide, WingSurfaceClaims claims)
		{
			throw new NotImplementedException();
		}

		public virtual bool TryPlaceOnWing(WingSurfaceClaims claims, float placePosition, float2 originalScale, float2 originalOffset)
		{
			throw new NotImplementedException();
		}

		public virtual string Validate(WingSlice[] slices)
		{
			return null;
		}
	}
}
