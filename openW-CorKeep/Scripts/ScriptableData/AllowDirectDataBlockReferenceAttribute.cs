using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
[Obsolete("Avoid using direct data block references wherever possible. Use DataBlockRef<> instead.")]
public class AllowDirectDataBlockReferenceAttribute : PropertyAttribute
{
}
