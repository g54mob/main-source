using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.Profiling;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	[Serializable]
	[Obfuscation(Exclude = true)]
	public class ProfilingCategory
	{
		public static List<ProfilingCategory> AvailableCategories = new List<ProfilingCategory>
		{
			new ProfilingCategory(ProfilerCategory.Ai.Name, new List<string> { "Custom" }),
			new ProfilingCategory(ProfilerCategory.Animation.Name, new List<string> { "Custom" }),
			new ProfilingCategory(ProfilerCategory.Audio.Name, new List<string> { "Custom" }),
			new ProfilingCategory(ProfilerCategory.FileIO.Name, new List<string> { "Custom", "File Bytes Read", "File Bytes Written", "File Handles Open", "File Reads Finished", "File Reads Started", "File Seeks", "Files Closed", "Files Opened", "Reads\u00a0in\u00a0Flight" }),
			new ProfilingCategory(ProfilerCategory.Gui.Name, new List<string> { "Custom" }),
			new ProfilingCategory(ProfilerCategory.Input.Name, new List<string> { "Custom" }),
			new ProfilingCategory(ProfilerCategory.Internal.Name, new List<string> { "Custom" }),
			new ProfilingCategory(ProfilerCategory.Lighting.Name, new List<string> { "Custom", "Global Illumination Support" }),
			new ProfilingCategory(ProfilerCategory.Loading.Name, new List<string> { "Custom", "Audio Reads", "Entities Reads", "Mesh Reads", "Other Reads", "Scripting Reads", "Texture Reads", "Virtual\u00a0Texture\u00a0Reads" }),
			new ProfilingCategory(ProfilerCategory.Memory.Name, new List<string>
			{
				"Custom", "AnimationClip Count", "AnimationClip Memory", "Asset Count", "Audio Reserved Memory", "Audio Used Memory", "AudioClip Count", "AudioClip Memory", "Game Object Count", "GC Allocated In Frame",
				"GC Allocation In Frame Count", "GC Reserved Memory", "GC Used Memory", "Gix Reserved Memory", "Gíx Used Memory", "Material Count", "Material Memory", "Mesh Count", "Mesh Memory", "Object Count",
				"Physics Used Memory", "Profiler Reserved Memory", "Profiler Used Memory", "Scene Object Count", "System Used Memory", "Texture Count", "Texture Memory", "Total Reserved Memory", "Total Used Memory", "Video Reserved Memory",
				"Video Used Memory"
			}),
			new ProfilingCategory(ProfilerCategory.Network.Name, new List<string> { "Custom" }),
			new ProfilingCategory(ProfilerCategory.Particles.Name, new List<string> { "Custom" }),
			new ProfilingCategory(ProfilerCategory.Physics.Name, new List<string>
			{
				"Custom", "Active Constraints", "Active Dynamic Bodies", "Active Kinematic Bodies", "Articulation Bodies", "Broadphase Adds", "Broadphase Adds/Removes", "Broadphase Removes", "Colliders Synced", "Continuous Overlaps",
				"Discreet Overlaps", "Dynamic Bodies", "Modified Overlaps", "Narrowphase Lost Touches", "Narrowphase New Touches", "Narrowphase Touches", "Overlaps", "Physics Queries", "Rigidbodies Synced", "Static Colliders",
				"Trigger\u00a0Overlaps"
			}),
			new ProfilingCategory(ProfilerCategory.Render.Name, new List<string>
			{
				"Custom", "Batches Count", "CPU Main Thread Frame Time", "CPU Render Thread Frame Time", "CPU Total Frame Time", "Draw Calls Count", "Dynamic Batched Draw Calls Count", "Dynamic Batched Triangles Count", "Dynamic Batched Vertices Count", "Dynamic Batches Count",
				"Dynamic Batching Time", "GPU Frame Time", "Index Buffer Upload in Frame Bytes", "Index Buffer Upload In Frame Count", "Instanced Batched Draw Calls Count", "Instanced Batched Triangles Count", "Instanced Batched Vertices Count", "Instanced Batches Count", "Render Textures Bytes", "Render Textures Changes Count",
				"Render Textures Count", "SetPass Calls Count", "Shadow Casters Count", "Static Batched Draw Calls Count", "Static Batched Triangles Count", "Static Batched Vertices Count", "Static Batches Count", "Triangles Count", "Used Buffers Bytes", "Used Buffers Count",
				"Used Textures Bytes", "Used Textures Count", "Vertex Buffer Upload In Frame Bytes", "Vertex Buffer Upload In Frame Count", "Vertices Count", "Video Memory Bytes", "Visible Skinned Meshes Count"
			}),
			new ProfilingCategory(ProfilerCategory.Scripts.Name, new List<string> { "Custom" }),
			new ProfilingCategory(ProfilerCategory.Video.Name, new List<string> { "Custom" }),
			new ProfilingCategory(ProfilerCategory.VirtualTexturing.Name, new List<string> { "Custom" }),
			new ProfilingCategory(ProfilerCategory.Vr.Name, new List<string> { "Custom" })
		};

		public string Category { get; private set; }

		public List<string> Status { get; private set; }

		public ProfilingCategory(string category, List<string> status)
		{
			Category = category;
			Status = status;
		}
	}
}
