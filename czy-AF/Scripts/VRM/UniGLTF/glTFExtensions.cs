using System;
using System.Collections.Generic;
using UnityEngine;

namespace UniGLTF
{
	public static class glTFExtensions
	{
		private struct ComponentVec
		{
			public glComponentType ComponentType;

			public int ElementCount;

			public ComponentVec(glComponentType componentType, int elementCount)
			{
				ComponentType = componentType;
				ElementCount = elementCount;
			}
		}

		private static Dictionary<Type, ComponentVec> ComponentTypeMap = new Dictionary<Type, ComponentVec>
		{
			{
				typeof(Vector2),
				new ComponentVec(glComponentType.FLOAT, 2)
			},
			{
				typeof(Vector3),
				new ComponentVec(glComponentType.FLOAT, 3)
			},
			{
				typeof(Vector4),
				new ComponentVec(glComponentType.FLOAT, 4)
			},
			{
				typeof(UShort4),
				new ComponentVec(glComponentType.UNSIGNED_SHORT, 4)
			},
			{
				typeof(Matrix4x4),
				new ComponentVec(glComponentType.FLOAT, 16)
			},
			{
				typeof(Color),
				new ComponentVec(glComponentType.FLOAT, 4)
			}
		};

		private static glComponentType GetComponentType<T>()
		{
			ComponentVec value = default(ComponentVec);
			if (ComponentTypeMap.TryGetValue(typeof(T), out value))
			{
				return value.ComponentType;
			}
			if (typeof(T) == typeof(uint))
			{
				return glComponentType.UNSIGNED_INT;
			}
			if (typeof(T) == typeof(float))
			{
				return glComponentType.FLOAT;
			}
			throw new NotImplementedException(typeof(T).Name);
		}

		private static string GetAccessorType<T>()
		{
			ComponentVec value = default(ComponentVec);
			if (ComponentTypeMap.TryGetValue(typeof(T), out value))
			{
				return value.ElementCount switch
				{
					2 => "VEC2", 
					3 => "VEC3", 
					4 => "VEC4", 
					16 => "MAT4", 
					_ => throw new Exception(), 
				};
			}
			return "SCALAR";
		}

		private static int GetAccessorElementCount<T>()
		{
			ComponentVec value = default(ComponentVec);
			if (ComponentTypeMap.TryGetValue(typeof(T), out value))
			{
				return value.ElementCount;
			}
			return 1;
		}

		public static int ExtendBufferAndGetAccessorIndex<T>(this glTF gltf, int bufferIndex, T[] array, glBufferTarget target = glBufferTarget.NONE) where T : struct
		{
			return gltf.ExtendBufferAndGetAccessorIndex(bufferIndex, new ArraySegment<T>(array), target);
		}

		public static int ExtendBufferAndGetAccessorIndex<T>(this glTF gltf, int bufferIndex, ArraySegment<T> array, glBufferTarget target = glBufferTarget.NONE) where T : struct
		{
			if (array.Count == 0)
			{
				return -1;
			}
			int num = gltf.ExtendBufferAndGetViewIndex(bufferIndex, array, target);
			gltf.bufferViews[num].byteStride = 0;
			int count = gltf.accessors.Count;
			gltf.accessors.Add(new glTFAccessor
			{
				bufferView = num,
				byteOffset = 0,
				componentType = GetComponentType<T>(),
				type = GetAccessorType<T>(),
				count = array.Count
			});
			return count;
		}

		public static int ExtendBufferAndGetViewIndex<T>(this glTF gltf, int bufferIndex, T[] array, glBufferTarget target = glBufferTarget.NONE) where T : struct
		{
			return gltf.ExtendBufferAndGetViewIndex(bufferIndex, new ArraySegment<T>(array), target);
		}

		public static int ExtendBufferAndGetViewIndex<T>(this glTF gltf, int bufferIndex, ArraySegment<T> array, glBufferTarget target = glBufferTarget.NONE) where T : struct
		{
			if (array.Count == 0)
			{
				return -1;
			}
			glTFBufferView item = gltf.buffers[bufferIndex].Append(array, target);
			int count = gltf.bufferViews.Count;
			gltf.bufferViews.Add(item);
			return count;
		}

		public static int ExtendSparseBufferAndGetAccessorIndex<T>(this glTF gltf, int bufferIndex, int accessorCount, T[] sparseValues, int[] sparseIndices, int sparseViewIndex, glBufferTarget target = glBufferTarget.NONE) where T : struct
		{
			return gltf.ExtendSparseBufferAndGetAccessorIndex(bufferIndex, accessorCount, new ArraySegment<T>(sparseValues), sparseIndices, sparseViewIndex, target);
		}

		public static int ExtendSparseBufferAndGetAccessorIndex<T>(this glTF gltf, int bufferIndex, int accessorCount, ArraySegment<T> sparseValues, int[] sparseIndices, int sparseIndicesViewIndex, glBufferTarget target = glBufferTarget.NONE) where T : struct
		{
			if (sparseValues.Count == 0)
			{
				return -1;
			}
			int bufferView = gltf.ExtendBufferAndGetViewIndex(bufferIndex, sparseValues, target);
			int count = gltf.accessors.Count;
			gltf.accessors.Add(new glTFAccessor
			{
				byteOffset = 0,
				componentType = GetComponentType<T>(),
				type = GetAccessorType<T>(),
				count = accessorCount,
				sparse = new glTFSparse
				{
					count = sparseIndices.Length,
					indices = new glTFSparseIndices
					{
						bufferView = sparseIndicesViewIndex,
						componentType = glComponentType.UNSIGNED_INT
					},
					values = new glTFSparseValues
					{
						bufferView = bufferView
					}
				}
			});
			return count;
		}
	}
}
