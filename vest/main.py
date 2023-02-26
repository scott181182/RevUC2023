import time

import adafruit_pca9685
import board
import busio
import digitalio



# A sine wave over 16 data points.
tmpl = [
    1.0000, 0.9619, 0.8536, 0.6913,
    0.5000, 0.3087, 0.1464, 0.0381,
    0.0000, 0.0381, 0.1464, 0.3087,
    0.5000, 0.6913, 0.8536, 0.9619
]
TMPL_LENGTH = len(tmpl)



led = digitalio.DigitalInOut(board.LED)
led.direction = digitalio.Direction.OUTPUT

def led_burst(times=4):
    for i in range(times):
        led.value = True
        time.sleep(0.2)
        led.value = False
        time.sleep(0.2)



time.sleep(2)
i2c = busio.I2C(board.GP15, board.GP14, frequency=200000)
led_burst()

# pca1 = adafruit_pca9685.PCA9685(i2c, address=0x40)
# pca2 = adafruit_pca9685.PCA9685(i2c, address=0x41)
pca3 = adafruit_pca9685.PCA9685(i2c, address=0x42)
# pcas = [ pca1, pca2, pca3 ]
pcas = [ pca3 ]



def reset_all():
    for pca in pcas:
        pca.reset()
        pca.frequency = 60
        for i in range(0, 16):
            pca.channels[i].duty_cycle = 0
            reset_all()

def run_toggle():
    on = True
    while True:
        for pca in pcas:
            for i in range(0, 16):
                pca.channels[i].duty_cycle = 0xffff if on else 0
        print("On" if on else "Off")
        on = not on
        time.sleep(1.5)

def run_sine():
    tmpl_offset = 0
    while True:
        for pca in pcas:
            for i in range(0, 16):
                # pca.channels[i].duty_cycle = int(0xffff * tmpl[(tmpl_offset + i) % TMPL_LENGTH])
                pca.channels[i].duty_cycle = int(0xffff * tmpl[tmpl_offset])
                # print(pca.channels[i].duty_cycle)
                tmpl_offset = (tmpl_offset + 1) % TMPL_LENGTH

        time.sleep(0.25)

run_sine()
