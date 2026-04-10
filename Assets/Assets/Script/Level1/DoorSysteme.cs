using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Script.Level1
{
    public class DoorSysteme : MonoBehaviour
    {
        public GameObject objectOpener;
        public GameObject door;
        public GameObject Beam;
        private bool _openerAssigned = false;
        private bool _doorOpened = false;
        private BoxCollider2D _doorBeam;
        public BoxCollider2D edgeNextScene;
        

        void Start()
        {
            _doorBeam = Beam.GetComponent<BoxCollider2D>();
        }
        
        void Update()
        {
            if (_doorOpened) return; 
            

            if (!_openerAssigned && objectOpener != null)
            {
                _openerAssigned = true;
            }

            if (_openerAssigned && !objectOpener) 
            {
                _doorOpened = true;
                door.SetActive(true);
                _doorBeam.size = new Vector2(1.437733f, 5.7f);
                _doorBeam.offset = new Vector2(0.07f, 1.71f);
                edgeNextScene.enabled = true;
                
                
            }
        }
    }
}