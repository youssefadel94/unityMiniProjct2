using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
   // [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour 
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }  // the navmesh agent required for the path finding
        //public mainCharectar character { get; private set; }    // the character we are controlling
        public Transform target;                                        // target to aim for
        public Animator m_Animator;
        private bool m_Walking;
        private bool m_Attack;
        [SerializeField]
        float m_MoveSpeedMultiplier = 1f;
        [SerializeField]
        float m_AnimSpeedMultiplier = 1f;
        private Rigidbody m_Rigidbody;
        private CapsuleCollider m_Capsule;
        private float m_CapsuleHeight;
        private Vector3 m_CapsuleCenter;
        private object m_OrigGroundCheckDistance;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            //character = GetComponent<ThirdPersonCharacter>();
            m_Animator = GetComponent<Animator>();
            //character = GetComponent<mainCharectar>();
            ////agent.updateRotation = false;
            //agent.updatePosition = true;
            m_Rigidbody = GetComponent<Rigidbody>();
            m_Capsule = GetComponent<CapsuleCollider>();
            m_CapsuleHeight = m_Capsule.height;
            m_CapsuleCenter = m_Capsule.center;

            //m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
           
        }


        private void Update()
        {
            if (target != null) {
                Vector3 targetPostition = new Vector3(target.position.x,
                                       agent.transform.position.y,
                                       target.position.z);
                agent.transform.LookAt(targetPostition);
                agent.SetDestination(target.position);
                

                // Debug.Log(agent.remainingDistance > 2);
                if (agent.remainingDistance > 1 )
                {
                    if(agent.remainingDistance > 2) { 
                    agent.Resume();
                    m_Walking = true;
                    m_Attack =false;
                    }
                }
                else
                {
                    agent.Stop();
                    m_Walking = false;
                    m_Attack = true;

                }

            }
            UpdateAnimator();



        }

        void UpdateAnimator()
        {
            m_Animator.SetBool("Walk", m_Walking);
            m_Animator.SetBool("Attack", m_Attack);


        }

        void OnTriggerEnter(Collider obj)
        {
            if (obj.CompareTag("Player")) {
                if (m_Attack == true) {
                    Debug.Log("dec health");
                }
            }
        }
    }
}
