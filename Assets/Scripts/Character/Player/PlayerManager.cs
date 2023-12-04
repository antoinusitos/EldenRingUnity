using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AG
{
    public class PlayerManager : CharacterManager
    {
        private PlayerLocomotionManager playerLocomotionManager = null;

        protected override void Awake()
        {
            base.Awake();

            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        }

        protected override void Update()
        {
            base.Update();

            if(!IsOwner)
            {
                return;
            }

            playerLocomotionManager.HandleAllMovement();
        }

        protected override void LateUpdate()
        {
            if(!IsOwner)
            {
                return;
            }

            base.LateUpdate();

            PlayerCamera.instance.HandleAllCameraActions();
        }

        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();

            if(IsOwner)
            {
                PlayerCamera.instance.player = this;
            }
        }

    }
}