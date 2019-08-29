﻿using System.Collections.Generic;
using UnityEngine;

namespace CartoonCar
{
    public class Path : MonoBehaviour
    {
        public Color lineColor;

        private List<Transform> nodes = new List<Transform>();

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = lineColor;

            Transform[] pathTransforms = GetComponentsInChildren<Transform>();
            nodes = new List<Transform>();

            foreach (var pathTransform in pathTransforms)
            {
                if (pathTransform != transform)
                {
                    nodes.Add(pathTransform);
                }
            }

            for (int i = 0; i < nodes.Count; i++)
            {
                Vector3 currentNode = nodes[i].position;
                Vector3 previousNode = Vector3.zero;

                if (i > 0)
                {
                    previousNode = nodes[i - 1].position;
                }
                else if (i == 0 && nodes.Count > 1)
                {
                    previousNode = nodes[nodes.Count - 1].position;
                }

                Gizmos.DrawLine(previousNode, currentNode);
                Gizmos.DrawWireSphere(currentNode, 0.3f);
            }
        }
    }
}