//
//  FirstViewController.swift
//  telecomando_robot
//
//  Created by Roberto D'Isanto on 02/07/2020.
//  Copyright © 2020 Roberto D'Isanto. All rights reserved.
//

import UIKit

class FirstViewController: UIViewController {
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
    }
    
    @IBOutlet weak var textViewOut1: UITextView!
    
    @IBAction func getStato(_ sender: Any) {
        getStato()
    }
    
    func getStato() {
        var semaphore = DispatchSemaphore (value: 0)
        
        var request = URLRequest(url: URL(string: "https://hackathon.tim.it/CRI1/status")!,timeoutInterval: Double.infinity)
        request.addValue("RIMOSSO_COME_RICHIESTO", forHTTPHeaderField: "apikey")
        print("INSERIRE API PER BACKEND TIM!");
        
        request.httpMethod = "GET"
        
        var testo = ""
        
        let task = URLSession.shared.dataTask(with: request) { data, response, error in
            guard let data = data else {
                print(String(describing: error))
                return
            }
            print(String(data: data, encoding: .utf8)!)
            testo = String(data: data, encoding: .utf8)!
            
            semaphore.signal()
        }
        
        task.resume()
        semaphore.wait()
        
        self.textViewOut1.text = testo
    }
    
}

