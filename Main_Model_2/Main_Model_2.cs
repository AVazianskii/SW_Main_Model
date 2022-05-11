using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SW_Character_creation;
using Races_libs;
using Age_status_libs;
using Attribute_libs;
using Skills_libs;

namespace Character_design
{
    public class Main_model : BaseViewModel_2
    {
        private static Main_model instance;

        public Race__manager Race_Manager;
        public Age_status_manager Age_status_Manager;
        public Attribute_manager Attribute_Manager;
        public Skill_manager Skill_Manager;
        public Range_manager Range_Manager;
        public Force_skill_manager Force_skill_Manager;


        private Main_model()
        {
            Race_Manager = Race__manager.GetInstance();
            Skill_Manager = Skill_manager.GetInstance();
            Range_Manager = Range_manager.GetInstance();
            Age_status_Manager = Age_status_manager.GetInstance();
            Attribute_Manager = Attribute_manager.GetInstance();
            Force_skill_Manager = Force_skill_manager.GetInstance();
            Load_async(Race_Manager);
            Load_async(Skill_Manager);
            Load_async(Attribute_Manager);
            Load_all_from(Range_Manager);
            Load_all_from(Age_status_Manager);
            Load_all_from(Force_skill_Manager);


        }

        public static Main_model GetInstance()
        {
            if (instance == null)
            {
                instance = new Main_model();
            }
            return instance;
        }
        private void Load_all_from(Abstract_manager Manager)
        {
            Manager.Run_download_and_upload_process();
        }
        private async void Load_async(Abstract_manager _Manager_1)
        {
            await Task.Run(() => Load_all_from(_Manager_1));
        }
    }
}
