using UnityEngine;

namespace Assets.Script
{
    public class CameraPosition : MonoBehaviour
    {
        public Transform target;
        public GameObject followingObject;
        public float xmin, xmax, ymin, ymax;

        private float _halfWidth;

        void Start()
        {
            _halfWidth = Camera.main.orthographicSize * Camera.main.aspect / 2f;
        }

        void Update()
        {
            float targetX;

            if (followingObject.transform.position.x < xmin)
                targetX = xmin ;
            else if (followingObject.transform.position.x > xmax)
                targetX = xmax;
            else
                targetX = followingObject.transform.position.x;

            target.position = new Vector3(targetX, target.position.y, target.position.z);
        }
    }
}