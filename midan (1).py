# Write your code here :-)
# must
import socket
from time import sleep
import RPi.GPIO as GPIO
import sys
from threading import Event
global exit
exit = Event()  


# define pin numbring
GPIO.setmode(GPIO.BOARD)  # must 
pin_sensor = 8
pin_up = 16
pin_down = 22
pin_up_down = 12
pin_day_night = 10

# set which pin input and which output
#  & pull up and down pin for clear reading
GPIO.setwarnings(False)  # must
GPIO.setup(pin_up,GPIO.IN,pull_up_down=GPIO.PUD_UP)
GPIO.setup(pin_down,GPIO.IN,pull_up_down=GPIO.PUD_UP)
GPIO.setup(pin_sensor,GPIO.IN,pull_up_down=GPIO.PUD_DOWN)
GPIO.setup(pin_day_night,GPIO.OUT)
GPIO.setup(pin_up_down,GPIO.OUT)

# setup UDP protocol 
ip = "192.168.1.27"   # controller PC IP address
por = 8000

# inti_sensor_
sensor = 0

########################         NOTE/if there is time issue please delete the three sleeP(.1) 
########################              but it will make progrm sensor in one level .


while True:
    # read hit sensor three time for three level
    sensor = sensor + GPIO.input(pin_sensor)
    sleep(.1)
    sensor = sensor + GPIO.input(pin_sensor)
    sleep(.1)
    sensor = sensor + GPIO.input(pin_sensor)
    sleep(.1)
    
    # read up down F_back
    up     = GPIO.input(pin_up)
    down   = GPIO.input(pin_down)



    ####################### UDP start ################################
    try:
        # openn socket in udp format
        so = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)


        # send mssg = id + up f_back + down f_back + hit sensor
        s = "1" + str(up) + str(down) + str(sensor)
        ss = str.encode(s)
        so.sendto(ss, (ip, por))
        sleep(.1)
       

        #so.bind((ip,por))
        #chck = so.connect_ex((ip,por))
        
        ###################################################################
        ####################### recv wait for ever ########################
        ##################### try & cach will not help ####################
        ###################################################################



        #rcev mssg = IDs + up/down 0/1 + night/day 0/1
        r = ""
        rr = str.encode(r)
        r = so.recvfrom(4096)
        if r[0][0] == 49:      # check if server choose my id 1
            if r[0][8] == 49:  # recv up
                GPIO.output(pin_up_down, GPIO.HIGH)
            if r[0][8] == 48:  # recv down
                GPIO.output(pin_up_down, GPIO.LOW)
            if r[0][9] == 49:  # recv night = light on
                GPIO.output(pin_day_night, GPIO.HIGH)
            if r[0][9] == 48:  # recv day   = light of
                GPIO.output(pin_day_night, GPIO.LOW)
        print(r)
        so.close()
        ########################### UDP end ###############################

            
    
    except:
        print("error")
    # re_dec_sensor
    sensor = 0